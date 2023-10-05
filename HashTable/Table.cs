using System.Collections;

namespace HashTable;

public class Table
{
    private Dictionary<int, int> _hashTable = [];

    public int this[string key]
    {
        get => Get(key);
        set => TryAdd(key, value);
    }


    public void TryAdd(string key, int value)
    {
        int hash = GetHash(key);
        if (!_hashTable.ContainsKey(hash))
        { _hashTable.Add(hash, value); }
        else { Collisions(value, hash); }
    }

    public int Get(string key)
    {
        int hash = GetHash(key);
        if (!_hashTable.TryGetValue(hash, out int value))
        {
            throw new Exception($"Отсутствует ключ {key}");
        }
       
        return value;
    }

    public bool Remove(string key)
    {
        int hash = GetHash(key);
        if (!_hashTable.TryGetValue(hash, out int value))
        {
            return false;
        }

        _hashTable.Remove(hash);
        return true;
    }

    public void View()
    {
        SortedDictionary<int, int> sorted = new(_hashTable);
        _hashTable = sorted.ToDictionary();
        Console.WriteLine("Таблица:");
        foreach ((int key, int value) in _hashTable)
        {
            Console.WriteLine($"{key}:{value}");
        }
    }

    private int GetHash(string key) => key.Length % 20;

    private void Collisions(int value, int hash)
    {
        while (_hashTable.ContainsKey(++hash)) {}
        _hashTable.Add(hash, value);
    }
}