namespace Task1
{
    internal class WorkingArray
    {
        public void MovesAll(Movement[] mov)
        {
            foreach (var m in mov)
            {
                m.Move();
            }
        }
        public void MoveByType(Movement[] mov, int type)
        {
            foreach (var m in mov)
            {
                switch (type)
                {
                    case 1:
                        if (m is Running)
                            m.Move();
                        break;
                    case 2:
                        if (m is Walking)
                            m.Move();
                        break;
                    case 3:
                        if (m is Cycling)
                            m.Move();
                        break;
                    default:
                        break;
                }
            }
        }
        public void SortToArray(Movement[] mov, int priority)
        {
            int idx = -1;

            for (int i = 0; i < mov.Length; i++)
            {
                if (priority == 1 && mov[i] is Running ||
                    priority == 2 && mov[i] is Walking ||
                    priority == 3 && mov[i] is Cycling)
                {
                    idx = i;
                    break;
                }
            }
            if (idx <= 0)
            {
                if (idx <= 0)
                    return;
            }
            var tmp = mov[0];
            mov[0] = mov[idx];
            mov[idx] = tmp;
        }
    }
}
