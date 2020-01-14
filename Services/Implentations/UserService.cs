using Common.HttpHelpers;
using Domain.Models;
using Infraestructure.Context;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implentations
{
    public class UserService : IServiceBase<User>
    {
        public EResponseBase<User> Get(int ID)
        {
            EResponseBase<User> response = new EResponseBase<User>();
            try
            {
                using (var context = new DataContext())
                {
                    response.Object = context.Users.Where(x => x.UserID == ID && x.State == true).FirstOrDefault();
                }
                response.IsSuccess = true;
                response.Message = "Success";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
                return response;
            }
        }

        //public EResponseBase<User> Get(string ID)
        //{
        //    EResponseBase<User> response = new EResponseBase<User>();
        //    try
        //    {
        //        using (var context = new DataContext())
        //        {
        //            response.Object = context.Users.Where(x => x.UserID == ID && x.State == true).FirstOrDefault();
        //        }
        //        response.IsSuccess = true;
        //        response.Message = "Success";
        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Message = ex.Message;
        //        response.IsSuccess = false;
        //        return response;
        //    }
        //}

        public EResponseBase<User> Login(string usuario, string password)
        {
            EResponseBase<User> response = new EResponseBase<User>();
            try
            {
                using (var context = new DataContext())
                {
                    response.Object = context.Users.Where(x => x.UserName == usuario && x.Password == password).FirstOrDefault();
                }

                if (response.Object == null)
                {                    
                    response.Message = "Usuario y Contraseña incorrecta!";
                    response.Code = 201;
                }
                else
                {
                    response.Code = 200;
                    response.Message = "Success";
                }
                response.IsSuccess = true;


                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
                return response;
            }
        }


        public EResponseBase<User> GetList()
        {
            EResponseBase<User> response = new EResponseBase<User>();
            try
            {
                using (var context = new DataContext())
                {
                    response.List = context.Users.Where(x => x.State == true).ToList();
                }
                response.IsSuccess = true;
                response.Message = "Success";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
                return response;
            }
        }

        public EResponseBase<User> Add(User model)
        {
            EResponseBase<User> response = new EResponseBase<User>();
            try
            {
                using (var context = new DataContext())
                {
                    model.CreateAt = DateTime.Now;
                    //model.State = true;
                    context.Users.Add(model);                   
                    context.SaveChanges();
                    
                }
                response.IsSuccess = true;
                response.Message = "Success";
                response.Object = model;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
                return response;
            }
        }

        public EResponseBase<User> Update(User model)
        {
            EResponseBase<User> response = new EResponseBase<User>();
            try
            {
                using (var context = new DataContext())
                {
                    var User = context.Users.Where(x => x.UserID == model.UserID).FirstOrDefault();
                    User.Name = model.Name;
                    User.LastName = model.LastName;
                    //User.Email = model.Email;
                    //User.Birthdate = model.Birthdate;
                    context.SaveChanges();
                }
                response.IsSuccess = true;
                response.Message = "Success";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
                return response;
            }
        }

        public EResponseBase<User> Delete(int ID)
        {
            EResponseBase<User> response = new EResponseBase<User>();
            try
            {
                using (var context = new DataContext())
                {
                    var item = context.Users.Where(x => x.UserID == ID).FirstOrDefault();
                    item.State = false;
                    context.SaveChanges();
                }
                response.IsSuccess = true;
                response.Message = "Success";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
                return response;
            }
        }

    }
}
