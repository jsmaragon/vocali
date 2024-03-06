using Coravel.Invocable;
using System;
using System.Threading.Tasks;

public class MedicalRecordUploader : IInvocable
{
    //TODO: Inject directory, Specification (policies list) from https://nugetmusthaves.com/Package/SpecificationExpress

    public MedicalRecordUploader()
    {

    }

    public Task Invoke()
    {
        Console.WriteLine("This is my first invocable!");
        return Task.CompletedTask;
    }
}
