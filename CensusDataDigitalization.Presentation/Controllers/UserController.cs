using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using CensusDataDigitalization.BAL;
using CensusDataDigitalization.BAL.Interfaces;
using CensusDataDigitalization.DTO.DTOs;
using CensusDataDigitalization.Presentation.Models;
using static CensusDataDigitalization.DTO.Enums;

//using System.Data.Entity.Infrastructure;
//catch Exceptions using 
//catch (RetryLimitExceededException /* dex */)
//{
//    //Log the error (uncomment dex variable name and add a line here to write a log.
//    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
//}

namespace CensusDataDigitalization.Presentation.Controllers
{
    public class UserController : ApiController
    {
        private IMapper mapUserDTO2ViewModel;
        private IMapper mapUserViewModel2DTO;

        private IUserBAL userBAL;

        public UserController(IUserBAL _userBAL)
        {
            this.userBAL = _userBAL;

            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDTO, UserViewModel>();
            }
            );
            mapUserDTO2ViewModel = mapperConfiguration.CreateMapper();


            MapperConfiguration mapperConfiguration1 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserViewModel, UserDTO>();
            }
            );
            mapUserViewModel2DTO = mapperConfiguration1.CreateMapper();
        }



        // GET: api/User/type
        /// <summary>
        /// get lis of Users Upon the Approval status
        /// </summary>
        /// <param name="requestType"></param>
        /// <returns></returns>
        [HttpGet]
        public IList<UserViewModel> GetUsers(int requestType)
        {
            IList<UserDTO> usersDTO = userBAL.GetUsersBAL(requestType);
            IList<UserViewModel> users = mapUserDTO2ViewModel.Map<IList<UserViewModel>>(usersDTO);
            foreach (UserViewModel user in users)
            {
                string path = HttpContext.Current.Server.MapPath(@"~/images/");
                string imagePath = Path.Combine(path, user.ImageUrl);

                user.ImageUrl = Convert.ToBase64String(File.ReadAllBytes(imagePath));
            }

            return users;
        }

        // GET: api/User/5
        /// <summary>
        /// Get user detils by his Unique ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(UserViewModel))]
        public IHttpActionResult GetUserById(int id)
        {
            IHttpActionResult result;
            UserDTO userDTO = userBAL.GetUserByIdBAL(id);
            UserViewModel userViewModel = mapUserDTO2ViewModel.Map<UserViewModel>(userDTO);

            string path = HttpContext.Current.Server.MapPath(@"~/images/");
            string imagePath = Path.Combine(path, userViewModel.ImageUrl);

            userViewModel.ImageUrl = Convert.ToBase64String(File.ReadAllBytes(imagePath));

            if (userViewModel == null)
            {
                result = NotFound();
            }
            else
            {
                result = Ok(userViewModel);
            }

            return result;
        }

        /// <summary>
        /// Post user Data to the database
        /// </summary>
        /// <param name="userViewModel"></param>
        /// <returns></returns>
        [ResponseType(typeof(UserViewModel))]
        public IHttpActionResult PostUser(UserViewModel userViewModel)
        {
            IHttpActionResult result;

            UserDTO userDTO = userBAL.ValidateUserSignUpBAL(userViewModel.EmailID, userViewModel.AadharNo);

            if (userDTO.EmailID != null || userDTO.AadharNo != null)
            {
                result = Ok(mapUserDTO2ViewModel.Map<UserViewModel>(userDTO));
            }
            else
            {
                string path = HttpContext.Current.Server.MapPath(@"~/Images/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path); //Create directory if it doesn't exist
                }

                string imageName = userViewModel.FirstName + DateTime.Now.GetHashCode().ToString() + ".jpg";
                string imagePath = Path.Combine(path, imageName);
                byte[] bytes = Convert.FromBase64String(userViewModel.ImageUrl);

                File.WriteAllBytes(imagePath, bytes);

                if (ModelState.IsValid)
                {
                    userViewModel.ImageUrl = imageName;
                    UserDTO user = mapUserViewModel2DTO.Map<UserDTO>(userViewModel);
                    UserDTO userAdded = userBAL.AddUserBAL(user);
                    userViewModel = mapUserDTO2ViewModel.Map<UserViewModel>(userAdded);

                    result = Ok(userViewModel);

                }
                result = BadRequest();
            }

            return result;
        }

        // PUT: api/User/5
        /// <summary>
        /// Change Request Status into the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="stat"></param>
        /// <returns></returns>
        [HttpPut, ResponseType(typeof(void))]
        public IHttpActionResult UpdateUserStatus(int id, ApprovalStatus stat)
        {
            IHttpActionResult result;

            UserDTO userDTO = userBAL.UpdateUserBAL(id, stat);
            UserViewModel user = mapUserDTO2ViewModel.Map<UserViewModel>(userDTO);

            if (user != null)
            {
                result = Ok(user);
            }
            else
            {
                result = BadRequest();
            }

            return result;
        }
    }
}