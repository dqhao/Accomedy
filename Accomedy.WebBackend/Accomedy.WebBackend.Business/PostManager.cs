using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Accomedy.WebBackend.Data;
using Accomedy.WebBackend.Entities;
using Accomedy.WebBackend.Model;
using Accomedy.WebBackend.Service.FlexibleSearch;
using Accomedy.WebBackend.Share;
using ExpressMapper.Extensions;

namespace Accomedy.WebBackend.Business
{
    public class PostManager : IPostManager
    {
        IPostRepository _postRepo;
        IFlexibleSearchService _flexSearchSvc;

        public PostManager(IPostRepository postRepository, IFlexibleSearchService flexSearchSvc)
        {
            _postRepo = postRepository;
            _flexSearchSvc = flexSearchSvc;
        }

        public PostModel Create(PostModel model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string[] ids)
        {
            throw new NotImplementedException();
        }

        public PostModel Edit(PostModel changedModel)
        {
            throw new NotImplementedException();
        }

        public PostModel GetDetailById(string id)
        {
            throw new NotImplementedException();
        }

        public IList<string> InspectFlexibleSearch(SearchModel criteria)
        {
            throw new NotImplementedException();
        }

        public bool IsExisted(string id)
        {
            throw new NotImplementedException();
        }

        public bool IsValidKey(string key)
        {
            throw new NotImplementedException();
        }

        public TPagination<PostModel> Search(SearchModel criteria)
        {
            if (criteria == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                string xmlSearchFields = _flexSearchSvc.AnalyzeSearchCriteria<POST>(criteria.Criterias);
                PropertyInfo sortingField = _flexSearchSvc.WhichSortingField<POST>(criteria.SortedBy);

                var ents = _postRepo.Find(xmlSearchFields, sortingField,
                    criteria.IsDescSorting ? SortingEnum.DESC : SortingEnum.ASC,
                    criteria.PageNumber, criteria.PageCount);

                var results = ents.Map<TPagination<POST>, TPagination<PostModel>>();

                return results;
            }
        }
    }
}
