#include <iostream>

using namespace std;

int main()
{
	int n;
	// ввод
	cin >> n;

	int res = 0;
	for (int i = 0; i < n; i++) // цикл до n
	{
		res += i; /* Начало 
				     Комментарий
					 Конец */
	}

	// вывод
	cout << res << endl;

	return 0;
}