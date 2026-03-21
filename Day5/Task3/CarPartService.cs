namespace Task3
{
    internal class CarPartService
    {
        private Random r = new Random();
        public CarPart[] CreateRandomParts(int n)
        {
            CarPart[] parts = new CarPart[n];
            for (int i = 0; i < n; i++)
            {
                int type = r.Next(0, 2);
                int name = i + 1;
                if (type == 0)
                {
                    int voltage = r.Next(6, 25);
                    parts[i] = new Battery(name, voltage);
                }
                else
                {
                    int weight = r.Next(10, 151);
                    parts[i] = new Gearbox(name, weight);
                }
            }
            return parts;
        }
        public void SortPartsByName(CarPart[] parts, bool ascending)
        {
            Array.Sort(parts, (a, b) =>
            {
                if (a.Name == b.Name)
                {
                    return 0;
                }
                if (ascending)
                {
                    if (a.Name < b.Name)
                    {
                        return -1;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    if (a.Name > b.Name)
                    {
                        return -1;
                    }
                    else
                    {
                        return 1;
                    }
                }
            });
        }
        public CarPart[] GetMechanicalParts(CarPart[] parts)
        {
            int count = 0;
            for (int i = 0; i < parts.Length; i++)
                if (parts[i] is IMechanicalComponent)
                    count++;

            CarPart[] result = new CarPart[count];
            int index = 0;
            for (int i = 0; i < parts.Length; i++)
                if (parts[i] is IMechanicalComponent)
                    result[index++] = parts[i];

            return result;
        }
        public CarPart[] GetElectricalParts(CarPart[] parts)
        {
            int count = 0;
            for (int i = 0; i < parts.Length; i++)
                if (parts[i] is IElectricalComponent)
                    count++;

            CarPart[] result = new CarPart[count];
            int index = 0;
            for (int i = 0; i < parts.Length; i++)
                if (parts[i] is IElectricalComponent)
                    result[index++] = parts[i];

            return result;
        }
    }
}
