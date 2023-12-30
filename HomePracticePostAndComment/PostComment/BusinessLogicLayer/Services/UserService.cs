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
    public class UserService
    {
        public static UserDTO AddUser(UserDTO c)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<UserDTO, User>(); cfg.CreateMap<User, UserDTO>(); });
            var mapper = new Mapper(config);
            var data = mapper.Map<User>(c);
            var data2 = DataAccessFactory.UserData().Create(data);
            return mapper.Map<UserDTO>(data2);
        }
        // public static UserDTO UpdateUser(UserDTO c) 
        //{
        //  var config = new MapperConfiguration(cfg => { cfg.CreateMap<UserDTO, User>(); cfg.CreateMap<User, UserDTO>(); });
        //var mapper = new Mapper(config);
        //var data = mapper.Map<User>(c);
        //var data2 = DataAccessFactory.UserData().Update(data);
        //return mapper.Map<UserDTO>(data2);
        //}
        public static UserDTO UpdateUser(UserDTO u)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<UserDTO, User>();
                c.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<User>(u);

            var ret = DataAccessFactory.UserData().Update(data);
            //if (ret != false)
            return mapper.Map<UserDTO>(ret);
            //return false;
        }
    }
}
