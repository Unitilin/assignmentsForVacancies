using System;

class Program
{
	static void Main(string[] args)
	{
		//Пример работоспособности
		Random random = new Random();				//Использование класса Random для генерации случайных чисел
		int size = random.Next(1, 20);				// Генерируем случайное число от 1 до 20 для размера массива A
		int[] A = new int[size];					// Создаем массив с сгенерированным случайным размером

		for (int i = 0; i < A.Length; i++)			//Перебор массива А
		{
			A[i] = random.Next(10);					// Генерируем случайное число от 0 до 9 для каждого элемента массива A
		}

		int result = Solution.solution(A);			//Присваеваем переменной result метод solution класса Solution
		Console.WriteLine(result);					//Выводит результат
		Console.ReadKey();							//Позволяет не закрывать окно и посмотреть выводимое значение
	}
}
class Solution
{
	public static int solution(int[] A)
	{
		int N = A.Length;							//Присваеваем переменной N значение длинны массива А
		int[] starts = new int[N];					//Инициализация массива начальной точки дисков
		int[] ends = new int[N];					//Инициализация массива конечной точки дисков

		for (int i = 0; i < N; i++)					//Перебор массива
		{
			starts[i] = i - A[i];					// starts[i] содержит начало диска (J - A[J])
			ends[i] = i + A[i];						// ends[i] содержит конец диска (J + A[J])
		}
			
		Array.Sort(starts);							//Сортировка
		Array.Sort(ends);							//массивов

		int count = 0;								// Счетчик пересекающихся пар дисков
		int activeDisks = 0;						// Количество активных дисков
		int j = 0;									// Указатель для массива ends

		for (int i = 0; i < N; i++)					// Проход по массиву
		{
			while (j < N && starts[i] > ends[j])	// Пока текущий диск (starts[i]) не пересекается с дисками, окончание которых уже прошло (ends[j]),
			{
				activeDisks--;						//Уменьшаем количество активных дисков и 
				j++;								//увеличиваем указатель j
			}

			count += activeDisks;                   // Увеличиваем счетчик на количество активных дисков

			if (count > 10000000)                   // Если количество пересекающихся пар превышает 10 000 000, 
			{		
				return -1;                          // возвращаем -1
			}

			activeDisks++;                          // Увеличиваем количество активных дисков для текущего диска
		}

		return count;                               // Возвращаем количество пересекающихся пар дисков
	}
}
