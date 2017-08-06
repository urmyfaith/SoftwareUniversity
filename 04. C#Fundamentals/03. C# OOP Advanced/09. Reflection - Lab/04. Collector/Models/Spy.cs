﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    private List<string> fieldsToInvestigate;

    public Spy()
    {
        this.fieldsToInvestigate = new List<string>();
    }

    public List<string> FieldsToInvestigate
    {
        get { return this.fieldsToInvestigate; }
        private set
        {
            this.fieldsToInvestigate = value;
        }
    }

    public string SteelFieldInfo(string investigatedClass, params string[] requestedFields)
    {
        Type classType = Type.GetType(investigatedClass);

        FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance |
                                                      BindingFlags.Static |
                                                      BindingFlags.NonPublic |
                                                      BindingFlags.Public);

        StringBuilder stringBuilder = new StringBuilder();

        Object classInstance = Activator.CreateInstance(classType, new object[] { });

        stringBuilder.AppendLine($"Class under investigation: {investigatedClass}");

        foreach (FieldInfo field in classFields.Where(f => requestedFields.Contains(f.Name)))
        {
            stringBuilder.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return stringBuilder.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        Type classType = Type.GetType(className);
        FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance |
                                                      BindingFlags.Public |
                                                      BindingFlags.Static);

        MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Instance |
                                                               BindingFlags.Public);

        MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.Instance |
                                                                  BindingFlags.NonPublic);

        StringBuilder stringBuilder = new StringBuilder();

        foreach (FieldInfo field in classFields)
        {
            stringBuilder.AppendLine($"{field.Name} must be private!");
        }

        foreach (MethodInfo method in classNonPublicMethods.Where(m => m.Name.StartsWith("get")))
        {
            stringBuilder.AppendLine($"{method.Name} have to be public!");
        }

        foreach (MethodInfo method in classPublicMethods.Where(m => m.Name.StartsWith("set")))
        {
            stringBuilder.AppendLine($"{method.Name} have to be private!");
        }

        return stringBuilder.ToString().Trim();
    }

    public string RevealPrivateMethods(string className)
    {
        Type classType = Type.GetType(className);
        MethodInfo[] privateMethods = classType.GetMethods(BindingFlags.Instance |
                                                           BindingFlags.NonPublic);

        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.AppendLine($"All Private Methods of Class: {className}");
        stringBuilder.AppendLine($"Base Class: {classType.BaseType.Name}");

        foreach (var method in privateMethods)
        {
            stringBuilder.AppendLine(method.Name);
        }

        return stringBuilder.ToString().Trim();
    }

    public string CollectGettersAndSetters(string className)
    {
        Type classType = Type.GetType(className);
        MethodInfo[] methods = classType.GetMethods(BindingFlags.Instance |
                                                    BindingFlags.NonPublic |
                                                    BindingFlags.Public);

        StringBuilder strinBuilder = new StringBuilder();

        foreach (var getter in methods.Where(m => m.Name.StartsWith("get")))
        {
            strinBuilder.AppendLine($"{getter.Name} will return {getter.ReturnType}");
        }

        foreach (var setter in methods.Where(m => m.Name.StartsWith("set")))
        {
            strinBuilder.AppendLine($"{setter.Name} will set field of {setter.GetParameters().First().ParameterType}");
        }

        return strinBuilder.ToString().Trim();
    }
}
