using CleanConnect.Common.Model.Errors;
using CleanDdd.Common.Model.Identity;
using NjantPublish.Core.Model;

namespace ServiceBase.Core.Model.Context
{
    public class ExampleModel: Base<LongIdentity, long>, IValidator
    {
        public string Property1 { get; private set;  }
        public string Property2 { get; }

        public ExampleModel()
        {
            Id = new LongIdentity(0);
        }

        public ExampleModel(LongIdentity id, string property1, string property2)
        {
            Property1 = property1;
            Property2 = property2;
            Id = id;
            Errors = new Validations();
        }

        public void UpdateProperty1(string value)
        {
            //validation
            if (string.IsNullOrEmpty(value))
            {
                //Null would likley be validated in the Dto but this is to show an example.
                Errors.AddError(ErrorCode.InvalidName, "You must supply a value.");
            }
            Property1 = value;
        }

        public bool IsValid()
        {
            //No errors then it is valid.
            //This should also be called before saving if you don't want to save invalid data.
            return Errors.Count == 0;
        }

        public Validations Errors { get; }
    }
}