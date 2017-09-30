using System;
using PapapaGo.Repositories;
using PapapaGo.Sample;

namespace PapapaGo.Factories
{
    public class RepositoryFactory
    {
        private static readonly Lazy<IBiddingRepository> _LazyBiddingRepository = new Lazy<IBiddingRepository>(() => new BiddingRepository(Config.DbConntectionString));

        public static IBiddingRepository GetBiddingRepository() => _LazyBiddingRepository.Value;
    }
}