using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.Concrete
{
    public class JokeRepository
    {
        public int AddJoke(string mText, int mMemberID)
        {
            NokatEntities entities = new NokatEntities();
            Joke _Jok = new Joke { JokeText = mText, MemberID = mMemberID,TimeAdded=DateTime.Now.ToUniversalTime() , Rank = 0 , Good= 0 , Bad = 0 };
            entities.Jokes.AddObject(_Jok);

            entities.SaveChanges();
            return _Jok.ID;

        }

        public string DecreaseRank(int mJokeID)
        {
            NokatEntities entities = new NokatEntities();

            //var _rank = --(entities.Jokes.Where(p => p.ID == mJokeID).First().Rank);
            Joke _Jok = (entities.Jokes.Where(p => p.ID == mJokeID).First());
            _Jok.Rank--;
            _Jok.Bad++;
            entities.SaveChanges();
            
            return _Jok.Rank.Value.ToString() + "_" + _Jok.Bad.Value.ToString();
        }

        public string IncreaseRank(int mJokeID)
        {
            NokatEntities entities = new NokatEntities();
            Joke _Jok = (entities.Jokes.Where(p => p.ID == mJokeID).First());
            _Jok.Rank++;
            _Jok.Good++;
            entities.SaveChanges();
            return _Jok.Rank.Value.ToString() + "_" + _Jok.Good.Value.ToString();
        } 

        public List<Joke> GetInterestList(int PageNo)
        {
            NokatEntities entities = new NokatEntities();//(p => p.TimeAdded.Value.Ticks * p.Rank)
            List<Joke> LJ =  entities.Jokes.OrderByDescending(x => x.TimeAdded).ToList();

            //data layer responsibility until making a specialezed stored procedure
            int PageSize = 10;
            if (PageNo != 0)
            {
                int StartElement = (PageNo - 1) * PageSize;
                if (LJ.Count > StartElement)
                    LJ.RemoveRange(0, StartElement);
                int ENDElement = (PageNo * PageSize) - 1;
                if (LJ.Count > PageSize)
                    LJ.RemoveRange(PageSize, LJ.Count - PageSize);
            }
            else
            {
                if (LJ.Count > PageSize)
                    LJ.RemoveRange(10, LJ.Count - PageSize);
            }

            return LJ;

        }



        public List<Joke> GetMembertInterestList(int iMemberID)
        {
            NokatEntities entities = new NokatEntities();//(p => p.TimeAdded.Value.Ticks * p.Rank)

            return entities.Jokes.Where(x => x.MemberID == iMemberID).OrderByDescending(x=>x.TimeAdded).ToList();
        }
    }
}
    