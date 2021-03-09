using CSVClaimParser;
using DataParser.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataParser.Repository
{
    public interface IUnitOfWork
    {
        IRepository<claim_staging> ClaimStagingRepository
        {
            get;
        }
        IRepository<tin_staging> TinStagingRepository
        {
            get;
        }

        IRepository<file_info> FileinfoRepository
        {
            get;
        }
        IRepository<rre_info> RREinfoRepository
        {
            get;
        }
        IRepository<tin_info> TininfoRepository
        {
            get;
        }


        IRepository<file_error> FileerrorRepository
        {
            get;
        }


    }
}
