using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using System.Web.Http.Cors;

namespace FibonacciCheckerAPI.Controllers
{   
    [EnableCors(origins: "http://localhost:44320", headers: "*", methods: "get")]
    public class FibonacciController : ApiController
    {
      
      //JSON-response
      public JObject Get(int number)
        {
           String str = "";

            if (isFibonacci(number) == true)
            {
                str = "{ \"answer\":\"Number belongs to the Fibonacci sequence\"}"; 
            } else
            {
                str = "{ \"answer\":\"Number does NOT belong to the Fibonacci sequence\"}";
            }
            JObject response = JObject.Parse(str);
            return response;
        }

        //Checks if given number belongs to Fibonacci sequence
        static Boolean isFibonacci(int numberToCheck)
        {
            int a = 0;
            int b = 1;
            if (numberToCheck == a || numberToCheck == b) return true;
            int c = a + b;
            while (c <= numberToCheck)
            {
                if (c == numberToCheck) return true;
                a = b;
                b = c;
                c = a + b;
            }
            return false;
        }
        
    }
}