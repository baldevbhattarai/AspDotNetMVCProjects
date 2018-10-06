using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ValidationMvc.Common;
namespace ValidationMvc.Models
{
    [MetadataType(typeof(UserMetaData))]
    public partial class User
    {
    }

    public class UserMetaData
    {
        //[Remote("IsUserNameAvailable", "Home", ErrorMessage = "UserName already in use.")]
        //following decoration is custom validator
        [RemoteClientServer("IsUserNameAvailable", "Home", ErrorMessage = "UserName already in use")]
        public string UserName { get; set; }
    }
}