﻿using AutoMapper;
using Demo.Areas.Admin.Models;
using Demo.Domaiin.DTOS;
using Demo.Domaiin.Entities;

namespace Demo
{
    public class WebProfile:Profile
    {

        public WebProfile()
        {

            CreateMap<AddAuthorModel, Author>().ReverseMap();
            CreateMap<UpdateAuthorModel, Author>().ReverseMap();
            CreateMap<AuthorSearchModel, AuthorSearchDto>().ReverseMap();

        }





    }
}
