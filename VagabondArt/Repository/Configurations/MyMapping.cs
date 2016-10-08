using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configurations
{
    public class MyMappings : Profile
    {
        public override string ProfileName
        {
            get { return "MyMappings"; }
        }
    }
}
