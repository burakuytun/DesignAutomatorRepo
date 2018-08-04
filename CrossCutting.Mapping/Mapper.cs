using System.Collections.Generic;

namespace CrossCutting.Mapping
{
    public class Mapper : IMapper
    {
        public Mapper()
        {
            Configure();
        }

        public TSource Clone<TSource>(TSource source)
        {
            return AgileObjects.AgileMapper.Mapper.DeepClone(source);
        }

        public TDestination Map<TDestination>(object source)
        {
            return AgileObjects.AgileMapper.Mapper.Map(source).ToANew<TDestination>();
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return AgileObjects.AgileMapper.Mapper.Map(source).OnTo(destination);
        }

        public IList<TDestination> Map<TSource, TDestination>(IList<TSource> source)
        {
            return AgileObjects.AgileMapper.Mapper.Map(source).ToANew<IList<TDestination>>();
        }

        //public IList<TDestination> Map<TSource, TDestination>(IList<TSource> source)
        //{
        //    IList<TDestination> destination = new List<TDestination>();

        //    foreach (var sourceItem in source)
        //    {
        //        destination.Add(AgileObjects.AgileMapper.Mapper.Map(sourceItem).ToANew<TDestination>());
        //    }

        //    return destination;
        //}

        public IList<TDestination> Map<TSource, TDestination>(IList<TSource> source, IList<TDestination> destination)
        {
            return AgileObjects.AgileMapper.Mapper.Map(source).OnTo(destination);
        }

        private static void Configure()
        {

        }
    }
}
