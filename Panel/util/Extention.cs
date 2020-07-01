using DAL.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Security.Claims;

namespace Panel
{
    public static class Extention
    {
        /// <summary>
        /// دریافت اطلاعات یوزر جاری از کوکی
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static string GetUserName(this ClaimsPrincipal user)
        {
            var Name = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            return Name;
        }


        public static string GetDisplayName(this Enum value)
        {
            return value.GetType()?
           .GetMember(value.ToString())?.First()?
           .GetCustomAttribute<DisplayAttribute>()?
           .Name;
        }


        public static List<T> GetListEnum<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToList();
            
        }

    }
}
