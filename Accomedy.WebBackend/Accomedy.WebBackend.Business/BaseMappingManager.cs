using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accomedy.WebBackend.Business
{
    using ExpressMapper;
    using Mappers;
    using System.Collections.Generic;

    public class BaseMappingManager : IMappingManager
    {
        #region Properties
        protected IEnumerable<IObjectMapper> Mappers
        {
            get
            {
                return mappers;
            }
        }
        #endregion

        #region Constructors
        public BaseMappingManager(IEnumerable<IObjectMapper> dtoMappers)
        {
            mappers = dtoMappers;
        }
        #endregion

        #region Overrides
        public void RegisterMapping()
        {
            if (Mappers != null)
            {
                foreach (var map in Mappers)
                {
                    map.Register();
                }

                Mapper.Compile();
            }
        }
        #endregion

        #region Attributes
        private IEnumerable<IObjectMapper> mappers;
        #endregion
    }
}
