using AutoMapper;

namespace DrugStore.Models.AutoMapper
{
    public class AutoMap
    {
        static AutoMap _instance;
        public static AutoMap Instance =>
            _instance ?? (_instance = new AutoMap(new MapProfile()));
        public IMapper Mapper { get; }
        public AutoMap(Profile profile)
        {
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(profile);
            });
            Mapper = mapConfig.CreateMapper();
        }
    }
}