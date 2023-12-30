using AutoMapper;
using BusinessLogicLayer.DTOs;
using DataAccessLayer;
using DataAccessLayer.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class PostService
    {
        public static List<PostDTO> Get()
        {
            var data = DataAccessFactory.PostData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Post, PostDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<PostDTO>>(data);
            return mapped; ;
        }
        public static PostDTO Get(int id) {
            var data = DataAccessFactory.PostData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Post, PostDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<PostDTO>(data);
            return mapped;
        }
        public static PostDTO AddPost(PostDTO c)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<PostDTO, Post>(); cfg.CreateMap<Post, PostDTO>(); });
            var mapper = new Mapper(config);
            var data = mapper.Map<Post>(c);
            var data1= DataAccessFactory.PostData().Create(data);
            return mapper.Map<PostDTO>(data1);
        }
    }
}
