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

        


        public V map<T,V>(T from, V to)
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new KafkaProfiles());  
            });

            var mapper = new Mapper(config);
            
            return mapper.Map<V>(from);

        }


    }
}
