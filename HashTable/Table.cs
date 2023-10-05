namespace HashTable;

public class Table
{
    private Dictionary<int, ValueBox> _hashTable = [];


    public void TryAdd(string key, int value)
    {
        int hash = GetHash(key);
        ValueBox valueBox = new(key, value);
        if (!_hashTable.ContainsKey(hash))
        { _hashTable.Add(hash, valueBox); }
        else { Collisions(valueBox, hash); }
    }

    public ValueBox Get(string key)
    {
        int hash = GetHash(key);
        if (!_hashTable.TryGetValue(hash, out ValueBox? value))
        {
            throw new Exception($"Отсутствует ключ {key}");
        }

        return value;
    }

    public bool Remove(string key)
    {
        int hash = GetHash(key);
        if (!_hashTable.TryGetValue(hash, out ValueBox? value))
        {
            return false;
        }

        _hashTable.Remove(hash);
        return true;
    }

    public void View()
    {
        SortedDictionary<int, ValueBox> sorted = new(_hashTable);
        _hashTable = sorted.ToDictionary();
        Console.WriteLine("Таблица:");
        foreach ((int key, ValueBox value) in _hashTable)
        {
            Console.WriteLine($"hash:{key} value:{value.Value}\t\tНачальный ключ:{value.Key}");
        }
    }

    private int GetHash(string key) => key.Length % 20;

    private void Collisions(ValueBox value, int hash)
    {
        while (_hashTable.ContainsKey(++hash)) { }
        _hashTable.Add(hash, value);
    }
}