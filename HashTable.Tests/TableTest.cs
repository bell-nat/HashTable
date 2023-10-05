using NUnit.Framework;

namespace HashTable.Tests;

public class Tests
{
    private Table _table;

    [SetUp]
    public void Setup() => _table = new Table();

    [TestCase("bread", 1)]
    [TestCase("eggplant", 2)]
    public void TryAdd_Value_Successful(string key, int expected)
    {
        _table.TryAdd(key, expected);

        int actual = _table.Get(key);
        Assert.AreEqual(expected, actual);
    }

    [TestCase("nuts", 3)]
    [TestCase("eggs", 4)]
    public void Get_Value_Successful(string key, int expected)
    {
        _table.TryAdd(key, expected);

        int actual = _table.Get(key);

        Assert.AreEqual(expected, actual);
    }

    [TestCase("nuts")]
    [TestCase("eggs")]
    public void Get_ByKey_ExceptionNoKey(string key)
    {
        Assert.Throws<Exception>(() => _table.Get(key), "67");
    }

    [TestCase("nuts", 3,"nuts", true)]
    [TestCase("eggs", 4, "nut",false)]
    public void Remove_Value_Successful(string key, int value, string current, bool expected)
    {
        _table.TryAdd(key, value);

        bool actual = _table.Remove(current);
        
        Assert.AreEqual(expected, actual);
    }
}