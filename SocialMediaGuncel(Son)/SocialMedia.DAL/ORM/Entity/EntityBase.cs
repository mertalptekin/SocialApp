using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialMedia.DAL.Models.Data.Entity
{
    public abstract class EntityBase
    {
        public int ID { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        //public bool IsValid
        //{
        //    get
        //    {
        //        return Validate();

        //    }
        //}

        //abstrat olan methodlar yada propertyler ovverride edilebilir;
        // virtualdan tek farklı base de işlem yaptırmamaktır;


        //protected abstract bool Validate();

       

    }
}