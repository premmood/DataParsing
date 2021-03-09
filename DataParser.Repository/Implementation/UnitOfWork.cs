using CSVClaimParser;
using DataParser.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataParser.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        ClaimContext _context = null;
        public UnitOfWork()
        {
            _context = new ClaimContext();
        }

        private IRepository<claim_staging> _claimInputRepository;
        private IRepository<tin_staging> _tinInputRepository;
        private IRepository<file_info> _fileInfoRepository;
        private IRepository<tin_info> _tinInfoRepository;
        private IRepository<rre_info> _rreInfoRepository;
        private IRepository<file_error> _fileErrorRepository;

        public IRepository<claim_staging> ClaimStagingRepository
        {
            get { return _claimInputRepository ?? (_claimInputRepository = new RepositoryBase<claim_staging>()); }
        }

        public IRepository<tin_staging> TinStagingRepository
        {
            get { return _tinInputRepository ?? (_tinInputRepository = new RepositoryBase<tin_staging>()); }
        }

        public IRepository<file_info> FileinfoRepository
        {
            get { return _fileInfoRepository ?? (_fileInfoRepository = new RepositoryBase<file_info>()); }
        }
        public IRepository<tin_info> TininfoRepository
        {
            get { return _tinInfoRepository ?? (_tinInfoRepository = new RepositoryBase<tin_info>()); }
        }
        public IRepository<rre_info> RREinfoRepository
        {
            get { return _rreInfoRepository ?? (_rreInfoRepository = new RepositoryBase<rre_info>()); }
        }

        public IRepository<file_error> FileerrorRepository
        {
            get { return _fileErrorRepository ?? (_fileErrorRepository = new RepositoryBase<file_error>()); }
        }


    }
}
