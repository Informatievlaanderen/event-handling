namespace Be.Vlaanderen.Basisregisters.EventHandling
{
    using System;
    
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class HideEventAttribute : Attribute
    { }
}
