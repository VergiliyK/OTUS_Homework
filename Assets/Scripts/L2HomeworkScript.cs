using System.Reflection;
using UnityEngine;

public class L2HomeworkScript : MonoBehaviour
{
    public L2HomeworkHealthComponent HealthComponent;
    public L2HomeworkExperienceComponent ExperienceComponent;
    private void Start()
    {
        HealthComponent = GetComponent<L2HomeworkHealthComponent>();
        ExperienceComponent = GetComponent<L2HomeworkExperienceComponent>();
        Task1();
        Task2();
        Task3();
    }

    /// <summary>
    /// Task #1. Define and log basic types.
    /// </summary>
    private static void Task1()
    {
        Debug.Log($"{MethodInfo.GetCurrentMethod().Name}");
        byte byteVar = 12;
        Debug.Log(string.Format("{0} is {1}.\n{0} = {2}.\nThe maximum of {1} is {3}, the mimimum is {4}.",
            nameof(byteVar),
            byteVar.GetType().Name,
            byteVar,
            byte.MaxValue,
            byte.MinValue
            ));

        short shortVar = 12345;
        Debug.Log(string.Format("{0} is {1}.\n{0} = {2}.\nThe maximum of {1} is {3}, the mimimum is {4}.",
            nameof(shortVar),
            shortVar.GetType().Name,
            shortVar,
            short.MaxValue,
            short.MinValue
            ));

        int intVar = 123456789;
        Debug.Log(string.Format("{0} is {1}.\n{0} = {2}.\nThe maximum of {1} is {3}, the mimimum is {4}.",
            nameof(intVar),
            intVar.GetType().Name,
            intVar,
            int.MaxValue,
            int.MinValue
            ));

        long longVar = 132465789L;
        Debug.Log(string.Format("{0} is {1}.\n{0} = {2}.\nThe maximum of {1} is {3}, the mimimum is {4}.",
            nameof(longVar),
            longVar.GetType().Name,
            longVar,
            long.MaxValue,
            long.MinValue
            ));

        float floatVar = 1.23456789f;
        Debug.Log(string.Format("{0} is {1}.\n{0} = {2}.\nThe maximum of {1} is {3}, the mimimum is {4}.",
            nameof(floatVar),
            floatVar.GetType().Name,
            floatVar,
            float.MaxValue,
            float.MinValue
            ));

        double doubleVar = 1.2345678912346789d;
        Debug.Log(string.Format("{0} is {1}.\n{0} = {2}.\nThe maximum of {1} is {3}, the mimimum is {4}.",
            nameof(doubleVar),
            doubleVar.GetType().Name,
            doubleVar,
            double.MaxValue,
            double.MinValue
            ));

        decimal decimalVar = 1.2345678912346789m;
        Debug.Log(string.Format("{0} is {1}.\n{0} = {2}.\nThe maximum of {1} is {3}, the mimimum is {4}.",
            nameof(decimalVar),
            decimalVar.GetType().Name,
            decimalVar,
            decimal.MaxValue,
            decimal.MinValue
            ));

        bool boolVar = true;
        Debug.Log(string.Format("{0} is {1}.\n{0} = {2}.",
            nameof(boolVar),
            boolVar.GetType().Name,
            boolVar
            ));

        char charVar = '!';
        Debug.Log(string.Format("{0} is {1}.\n{0} = {2}.",
            nameof(charVar),
            charVar.GetType().Name,
            charVar
            ));

        string stringVar = "Hello, World!";
        Debug.Log(string.Format("{0} is {1}.\n{0} = {2}.",
            nameof(stringVar),
            stringVar.GetType().Name,
            stringVar
            ));
    }

    /// <summary>
    /// Task #2. Do damage with int and float.
    /// </summary>
    private void Task2()
    {
        Debug.Log($"{MethodInfo.GetCurrentMethod().Name}");
        if (HealthComponent == null)
        {
            Debug.LogError($"{typeof(L2HomeworkHealthComponent).Name} was not found!");
            return;
        }
        for (int i = 0; i < 10; i++)
        {
            HealthComponent.TakeDamage(10);
            HealthComponent.TakeDamage(8.34f);
        }
    }

    /// <summary>
    /// Task #2. Gain experience. Level up.
    /// </summary>
    private void Task3()
    {
        Debug.Log($"{MethodInfo.GetCurrentMethod().Name}");
        if (ExperienceComponent == null)
        {
            Debug.LogError($"{typeof(L2HomeworkExperienceComponent).Name} was not found!");
            return;
        }
        ExperienceComponent.GainExperience(30);
        ExperienceComponent.LevelUp();
        ExperienceComponent.GainExperience(80);
        ExperienceComponent.LevelUp();
        ExperienceComponent.GainExperience(10);
        ExperienceComponent.LevelUp();
        ExperienceComponent.GainExperience(30);
        ExperienceComponent.LevelUp();
        ExperienceComponent.GainExperience(ExperienceComponent.Experience * 3);
        ExperienceComponent.LevelUp();
    }
}
