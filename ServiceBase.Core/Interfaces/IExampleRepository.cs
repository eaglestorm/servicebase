using System.Collections.Generic;
using ServiceBase.Core.Model.Context;

namespace ServiceBase.Core.Interfaces
{
    /// <summary>
    /// Interface for the repository is in the core so the core has no (or minimal) dependencies.
    /// </summary>
    public interface IExampleRepository
    {
        ExampleModel Get(long id);
        
        IList<ExampleModel> Get(int index, int size);

        ExampleModel Save(ExampleModel exampleModel);
    }
}