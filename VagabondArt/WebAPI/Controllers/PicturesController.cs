using System;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Services.Interfaces;
using WebAPI.Models;
using System.Net.Mail;
using Service.Services;

namespace WebAPI.Controllers
{
    [EnableCors(origins: AuthenticationService.GetOriginUrl, headers: "*", methods: "*")]
    public class PicturesController : ApiController
    {
        private readonly IPicturesService m_PicturesServices;
        private readonly IAuthenticationService m_TokenService;
        private readonly IPicturesOrderService m_PicturesOrderService;
        private readonly ISendEmailService m_SendEmailService;


        public PicturesController(IPicturesService picturesServices,
                                  IAuthenticationService tokenService,
                                  IPicturesOrderService picturesOrderService,
                                  ISendEmailService sendEmailService)
        {
            m_PicturesServices = picturesServices;
            m_TokenService = tokenService;
            m_PicturesOrderService = picturesOrderService;
            m_SendEmailService = sendEmailService;
        }

        [HttpGet]
        [Route("api/bg/pictures/{id:int}")]
        public IHttpActionResult GetBgPictures(int id)
        {
            var picture = m_PicturesServices.GetByIdPicture(id, EnumLanguages.Bulgarian);
            if (picture == null)
            {
                return NotFound();
            }
            return Ok(picture);
        }

        [HttpGet]
        [Route("api/en/pictures/{id:int}")]
        public IHttpActionResult GetEnPictures(int id)
        {
            var picture = m_PicturesServices.GetByIdPicture(id, EnumLanguages.English);
            if (picture == null)
            {
                return NotFound();
            }
            return Ok(picture);
        }

        [HttpGet]
        [Route("api/bg/pictures")]
        public IHttpActionResult GetAllBgPictures()
        {
            var pictures = m_PicturesServices.GetAllPictures(EnumLanguages.Bulgarian);
            return Ok(pictures);
        }

        [HttpGet]
        [Route("api/en/pictures")]
        public IHttpActionResult GetAllEnPictures()
        {
            var pictures = m_PicturesServices.GetAllPictures(EnumLanguages.English);
            return Ok(pictures);
        }

        [HttpPost]
        [Route("api/add/picture")]
        public HttpResponseMessage AddNewPcituret()
        {
            var files = HttpContext.Current.Request.Files;
            var form = HttpContext.Current.Request.Form;

            var isAuthorized = m_TokenService.IsAuthorized(form["AuthToken"]);
            var newPicture = new Services.Models.NewPicture();
            if (isAuthorized)
            {
                if (files.Count == 0)
                {
                    ModelState.AddModelError("Photo", "Please choose photo");
                }
                else
                {
                    newPicture.PicturePhoto = files[0];
                }

                ValidateNewPictureModel(form, newPicture);

                if (ModelState.IsValid)
                {
                    try
                    {
                        m_PicturesServices.AddNewPicture(new Services.Models.NewPicture
                        {
                            TitleBg = newPicture.TitleBg,
                            TitleEn = newPicture.TitleEn,
                            AuthorNameBg = newPicture.AuthorNameBg,
                            AuthorNameEn = newPicture.AuthorNameEn,
                            IsSold = newPicture.IsSold,
                            PicturePhoto = newPicture.PicturePhoto,
                            Price = newPicture.Price,
                            Size = newPicture.Size,
                            TechnicsBg = newPicture.TechnicsBg,
                            TechnicsEn = newPicture.TechnicsEn
                        });
                        return new HttpResponseMessage(HttpStatusCode.OK);
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("Error", "An error accured:" + ex.Message);
                    }
                }

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            ModelState.AddModelError("Unauthorized", "Unauthorized");
            return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, ModelState);

        }

        [HttpPost]
        [Route("api/order/pictures")]
        public HttpResponseMessage OrderPictures()
        {
            MailMessage mail = new MailMessage("artcentervagabond@gmail.com", "vzaycheva@gmail.com");
            mail.Subject = "New order";
            mail.IsBodyHtml = true;

            var picturesOrder = HttpContext.Current.Request.Form;

            mail.Body = m_SendEmailService.GenerateMailBodyMessageForPictureOrder(picturesOrder["Address"], picturesOrder["Comment"], picturesOrder["Phone"], picturesOrder["FullName"], picturesOrder["Email"]);
            if (picturesOrder["Products"] == null)
            {
                ModelState.AddModelError("CartIsEmpty", "The cart is empty");
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState); ;
            }
                if (!ValidateOrderPictureModel(picturesOrder))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }

                try
                {
                var picturesIds = picturesOrder["Products"].Split(',');

                for (int i = 0; i < picturesIds.Length; i++)
                    {
                        var picture = new Services.Models.PicturesOrder
                        {
                            Address = picturesOrder["Address"],
                            Comment = picturesOrder["Comment"],
                            Emmail = picturesOrder["Email"],
                            FullName = picturesOrder["FullName"],
                            Phone = picturesOrder["Phone"],
                            PictureId = int.Parse(picturesIds[i])
                        };

                        m_PicturesOrderService.MakeNewPicturesOrder(picture);
                        var pictureOrdered = m_PicturesServices.GetByIdPicture(int.Parse(picturesIds[i]), EnumLanguages.English);
                        mail.Body = mail.Body + m_SendEmailService.AddPictureInfoToMailBody(pictureOrdered.Title, pictureOrdered.AuthorName, pictureOrdered.Price.ToString());
                    }

                    m_SendEmailService.SendEmail(mail);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Error", "An error accured:" + ex.Message);
                }
            
               return new HttpResponseMessage(HttpStatusCode.OK);
        }

        private Services.Models.NewPicture ValidateNewPictureModel(NameValueCollection form, Services.Models.NewPicture picture)
        {
            if (string.IsNullOrEmpty(form["TitleBg"]) || string.IsNullOrEmpty(form["TitleEn"]))
                ModelState.AddModelError("Title", "Please fill both english and bulgarian title");
            else
                picture.TitleBg = form["TitleBg"];
                picture.TitleEn = form["TitleEn"];


            if (string.IsNullOrEmpty(form["TechnicsBg"]) || string.IsNullOrEmpty(form["TechnicsEn"]))
                ModelState.AddModelError("Technics", "Please fill both english and bulgarian technics");
            else
                picture.TechnicsBg = form["TechnicsBg"];
                picture.TechnicsEn = form["TechnicsEn"];


            if (string.IsNullOrEmpty(form["AuthorNameBg"]) || string.IsNullOrEmpty(form["AuthorNameEn"]))
                ModelState.AddModelError("Author", "Please fill both english and bulgarian author name");
            else
                picture.AuthorNameBg = form["AuthorNameBg"];
                picture.AuthorNameEn = form["AuthorNameEn"];


            if (string.IsNullOrEmpty(form["Price"]) || decimal.Parse(form["Price"]) == 0)
                ModelState.AddModelError("Price", "Please fill price");
            else
                picture.Price = decimal.Parse(form["Price"]);


            if (string.IsNullOrEmpty(form["Size"]))
                ModelState.AddModelError("Size", "Please fill size");
            else
                picture.Size = form["Size"];


            if (string.IsNullOrEmpty(form["IsSold"]))
                picture.IsSold = false;
            else picture.IsSold = true;

            return picture;
        }

        private bool ValidateOrderPictureModel(NameValueCollection pictureOrder)
        {
            if (String.IsNullOrEmpty(pictureOrder["Address"]) ||
                String.IsNullOrEmpty(pictureOrder["Comment"]) ||
                String.IsNullOrEmpty(pictureOrder["FullName"]) ||
                String.IsNullOrEmpty(pictureOrder["Email"]) ||
                String.IsNullOrEmpty(pictureOrder["Phone"]) ||
                pictureOrder["Products"].Length == 0)
            {
                ModelState.AddModelError("ErrorMandatoryFields", "All fields are mandatory");
                return false;
            }

            var allPicturesExist = true;
            var picturesIds = pictureOrder["Products"].Split(',');

            for (int i = 0; i < picturesIds.Length; i++)
            {
               if( m_PicturesServices.GetByIdPicture(int.Parse(picturesIds[i]),EnumLanguages.English) == null)
               {
                    allPicturesExist = false;
                }
            }

            if (!allPicturesExist)
            {
                ModelState.AddModelError("PictureDoesNotExist", "Picture does not exist");
                return false;
            }

            return true;
        }
    }
}

