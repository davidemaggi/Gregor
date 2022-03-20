using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gregor.MapService
{
    public class MapperService
    {

       public  MapperService() {

            _config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new KafkaProfiles());
            });

            _mapper = new Mapper(_config);



        }

        private readonly MapperConfiguration _config;
        public readonly Mapper _mapper;


       
    }
}
