using System;
using System.Collections.Generic;
using CleanConnect.Common.Contracts;
using CleanConnect.Common.Model.Errors;
using ServiceBase.Core.Interfaces;
using ServiceBase.Core.Messages;
using ServiceBase.Core.Model.Context;

namespace ServiceBase.Core.UseCase
{
    public class UpdateExampleUseCase : IUseCase<UpdateExampleRequest, UpdateExampleResponse>
    {
        private readonly IExampleRepository _repository;

        public UpdateExampleUseCase(IExampleRepository repository)
        {
            _repository = repository;
        }

        public UpdateExampleResponse Process(UpdateExampleRequest request)
        {
            try
            {
                var example = _repository.Get(request.Id);

                example.UpdateProperty1(request.Property1);
                if (example.IsValid())
                {
                    _repository.Save(example);
                    return new UpdateExampleResponse(true);
                }
                else
                {
                    return new UpdateExampleResponse(false, example.Errors);
                }
            }
            catch (Exception ex)
            {
                var validations = new Validations();
                validations.AddError(ErrorCode.Unexpected, "Unable to update example model.");
                return new UpdateExampleResponse(false, validations);
            }
        }
    }
}