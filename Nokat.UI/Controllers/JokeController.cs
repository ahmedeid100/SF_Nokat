using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DomainModel.Concrete;

using Facebook;
using DomainModel;
namespace Nokat.UI.Controllers
{
    public class JokeController : Controller
    {
        //
        // GET: /Joke/

        public ActionResult Index()
        {
            DomainModel.Concrete.JokeRepository JR = new DomainModel.Concrete.JokeRepository();        
            
            return View(JR.GetInterestList(0));
        }

        public ActionResult indexPartial(int? PageNo)
        {
            DomainModel.Concrete.JokeRepository JR = new DomainModel.Concrete.JokeRepository();

            if (PageNo == null) 
                PageNo = 0 ;
            return PartialView("indexPartial", JR.GetInterestList(PageNo.Value));
        }

        public ActionResult MemberIndexPartial(int MemberID)
        {
            DomainModel.Concrete.JokeRepository JR = new DomainModel.Concrete.JokeRepository();

            return PartialView("indexPartial", JR.GetMembertInterestList(MemberID));
        } 

        public int AddMember(string Access_Token)
        {
            var client = new FacebookClient(Access_Token);
            dynamic result = client.Get("me", new { fields = "name,id" });
            string Name = result.name;
            string FBID = result.id;

            MemberRepository MR = new MemberRepository();
            int memberID=MR.InsertNew(FBID, Name);
            
            return memberID;
        }


        public void PostJoke(string joketext, string memberID)
        {
            JokeRepository joke = new JokeRepository();
            joke.AddJoke(joketext, int.Parse(memberID));
        }

        public string IncreaseJoke(string jokeID)
        {
            JokeRepository joke = new JokeRepository();
            return joke.IncreaseRank(int.Parse(jokeID));           
            
        }

        public string DecreaseJoke(string jokeID)
        {
            JokeRepository joke = new JokeRepository();
            return joke.DecreaseRank(int.Parse(jokeID));

        }
    }
}
