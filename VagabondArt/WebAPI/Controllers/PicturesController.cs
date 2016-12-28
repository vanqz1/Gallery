﻿using System;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class PicturesController : ApiController
    {
        private readonly IPicturesService m_PicturesServices;

        public PicturesController(IPicturesService picturesServices)
        {
            m_PicturesServices = picturesServices;
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

            var newPicture = new NewPicture();

            if (files.Count == 0)
            {
                ModelState.AddModelError("Photo", "Please choose photo");
            }
            else
            {
                newPicture.PicturePhoto = files[0];
            }

            ValidateNewPictureModel(form,newPicture);

            if (ModelState.IsValid)
            {
                try
                {
                    m_PicturesServices.AddNewPicture(newPicture);
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("Error", "An error accured:" + ex.Message);
                }
            }

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            
        }

        private NewPicture ValidateNewPictureModel(NameValueCollection form, NewPicture picture)
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
                ModelState.AddModelError("IsSold", "Please fill is sold field");
            else picture.IsSold = bool.Parse(form["IsSold"]);

            return picture;
        }
    }
}

