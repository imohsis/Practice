using System;
using System.Collections.Generic;
using System.Text;

namespace PRACTICE.REPOSITORY
{
   
        public class ReturnObject
        {
            public long Id { get; set; }
            public bool Status { get; set; }
            public string StatusMessage { get; set; }
            public dynamic Data { get; set; }
        }

        //public class PersonDuplicateReturnObject : ReturnObject
        //{
        //    public PersonDuplicateReturnObject()
        //    {
        //        PossibleDuplicates = new List<PersonModel>();
        //    }
        //    public List<PersonModel> PossibleDuplicates { get; set; }
        //}
   
}
