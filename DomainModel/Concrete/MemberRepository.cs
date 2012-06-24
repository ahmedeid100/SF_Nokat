using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.Concrete
{
    public class MemberRepository
    {
        public int AddMember(string mName , string mFBID  )
        {
            NokatEntities entities = new NokatEntities();
            
            Member _Mem = new Member { Name = mName, FBID = mFBID };
            entities.Members.AddObject(_Mem);

            entities.SaveChanges();
            return _Mem.ID;

        }



        public int InsertNew(string mFBID, string mName)
        {
            NokatEntities entities = new NokatEntities();

            Member _Mem = new Member()
            {
                FBID = mFBID,
                Name = mName
            };

            Member MemVar = null;

            try
            {
                 MemVar = entities.Members.First(p => p.FBID == mFBID);
            }
            catch 
            {
                entities.Members.AddObject(_Mem);
                entities.SaveChanges();
                return _Mem.ID;
            }

            if (MemVar != null)
            {
                return MemVar.ID;
            }
            else
            {
                entities.Members.AddObject(_Mem);
                entities.SaveChanges();
                return _Mem.ID;
            }
            

        }


    }
}
