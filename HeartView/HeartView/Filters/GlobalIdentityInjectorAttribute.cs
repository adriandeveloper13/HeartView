//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using System.Web.Security;
//using CustomMembership;
//using HealthView.BusinessLogic.ModelCore;
//using HealthView.DataLayer;
//using LoggingService;

//namespace HeartView.Filters
//{
//    public class GlobalIdentityInjectorAttribute : ActionFilterAttribute, IAuthorizationFilter
//    {
//        #region public methods

//        public void OnAuthorization(AuthorizationContext filterContext)
//        {
//            try
//            {
//                HttpCookie authCookie = filterContext.HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
//                if (authCookie == null)
//                {
//                    return;
//                }
//                //Extract the forms authentication cookie
//                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
//                if (authTicket == null)
//                {
//                    return;
//                }
//                var concatenatedUserData = authTicket.UserData;
//                var data = concatenatedUserData.Split(new[]
//                {
//                    "#"
//                }, StringSplitOptions.RemoveEmptyEntries);
//                if (data.Count() != 1)
//                {
//                    return;
//                }
//                var validationToken = data[0];

//                if (validationToken == null)
//                {
//                    LogHelper.LogException<GlobalIdentityInjectorAttribute>("Validation token is invalid.");
//                }
//                SetCustomMembership(filterContext, validationToken);

//                FormsAuthentication.RenewTicketIfOld(authTicket);
//            }
//            catch (Exception ex)
//            {
//                LogHelper.LogException<GlobalIdentityInjectorAttribute>(ex.ToString());
//            }
//        }

//        #endregion

//        #region private methods

//        private static void SetCustomMembership(AuthorizationContext filterContext, string aspNetUserId)
//        {
//            var userIdentityDataEntries = DoctoriCore.Instance().GetUserIdentityData<UserIdentityData>(aspNetUserId);
//            if (userIdentityDataEntries == null || userIdentityDataEntries.Count == 0)
//            {
//                LogHelper.LogInfo<GlobalIdentityInjectorAttribute>("failed to retrieve userIdentityDataEntries!");
//                //TODO: remove this when in production
//                throw new Exception("failed to retrieve userIdentityDataEntries!");
//            }
//            var roles = GetRoles(userIdentityDataEntries);
//            if (roles == null || roles.Count == 0)
//            {
//                LogHelper.LogInfo<GlobalIdentityInjectorAttribute>("failed to retrieve roles!");
//                //TODO: remove this when in production
//                throw new Exception("failed to retrieve roles!");
//            }

//            SetIdentityAndPrincipal(userIdentityDataEntries.First(), filterContext, roles);
//        }

//        private static IList<string> GetRoles(IEnumerable<UserIdentityData> userIdentityData)
//        {
//            return userIdentityData?.Select(entry => entry.RoleId).ToList();
//        }

//        private static void SetIdentityAndPrincipal(UserIdentityData user, AuthorizationContext filterContext, IEnumerable<string> roles)
//        {
//            var identity = new CustomIdentity();

//            if (user == null)
//            {
//                return;
//            }

//            identity.AspNetUserId = user.AspNetUserId;
//            identity.Id = user.Id;
//            identity.CompanyId = user.CompanyId;
//            identity.CompanyName = user.CompanyName;
//            identity.WhiteLabelId = user.WhiteLabelId;
//            identity.FirstName = user.FirstName;
//            identity.LastName = user.LastName;
//            identity.Username = $"{user.FirstName} {user.LastName}";
//            identity.ProfilePictureUrl = user.ProfilePictureUrl;
//            identity.Phone = user.Phone;
//            identity.Cell = user.Cell;
//            identity.Fax = user.Fax;
//            identity.Country = user.Country;
//            identity.City = user.City;
//            identity.Address = user.Address;
//            identity.ZipCode = user.ZipCode;
//            identity.PilotNumber = user.PilotNumber;
//            identity.Type = user.Type;
//            identity.Position = user.Position;
//            identity.Role = user.Role;
//            identity.CostCenter = user.CostCenter;
//            identity.Status = user.Status;

//            var newUser = new CustomPrincipal(identity)
//            {
//                RoleIds = roles
//            };

//            filterContext.HttpContext.User = newUser;
//        }

//        #endregion
//    }
//}