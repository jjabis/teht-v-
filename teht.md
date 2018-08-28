#include <iostream>
#include <ai.h>
using namespace std;

int main()
{
	// Esimerkki.
	AI my_ai;
	double x = 0;
	double y = 0;
	double step = 0.1;
	
	bool kumpi = 1;
	bool jatk = 0;
	int ja = 1;

	my_ai.set_parameters(x, y);
	double ai_quality = my_ai.test_AI();
	//cout << "AI quality " << ai_quality << endl;
	
	
	while (ja < 100 && kumpi) {
		
		double ai_quality = my_ai.test_AI();
		
		double _x = x + step;
		x = _x;
		
		my_ai.set_parameters(x, y);
		double best_ai_quality = my_ai.test_AI();


		if (best_ai_quality < ai_quality && step >= 0.1) {
			step = -0.1;
		}
		else if (best_ai_quality < ai_quality && step <= -0.1) {
			kumpi = 0;
		}
		
		
		/*double ai_quality = my_ai.test_AI();
		
		cout << x << endl;
		
		double _x = x + step;
		x = _x;

		my_ai.set_parameters(x, y);
		double best_ai_quality = my_ai.test_AI();

		if (best_ai_quality <= ai_quality && step >= 0.1) {

			step = -0.1;
			

		}
		else if (best_ai_quality = ai_quality && step <= -0.1) {


			break;
		}
		*/
		
		//cout << x << endl;
		cout << "Best AI quality " << best_ai_quality << endl;
		//cout << "AI quality " << ai_quality << endl;




		ja++;
	}
	while (ja < 100 && !kumpi) {

		double ai_quality = my_ai.test_AI();

		double _y = y + step;
		y = _y;

		my_ai.set_parameters(x, y);
		double best_ai_quality = my_ai.test_AI();


		if (best_ai_quality < ai_quality && step >= 0.1) {
			step = -0.1;
		}
		else if (best_ai_quality < ai_quality && step <= -0.1) {
			
			break;
		}

		cout << "Best AI quality " << best_ai_quality << endl;
		ja++;
	}




	

	// Tehtävä:
	// Optimoi tekoälyn parametrit käyttäen Hill Climbing -algoritmia.
	// Ts. etsi sellaiset attack_range ja defense_range -parametrien
	// arvot, joilla .test_AI() palauttaa mahdollisimman suuren arvon.

	
	return 0;
}
