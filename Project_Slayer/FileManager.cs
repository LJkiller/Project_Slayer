using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Project_Slayer {
	//⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
	//⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⠿⠿⠿⠿⠻⠿⠻⠿⠿⠿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
	//⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢿⠿⠛⠛⠉⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠩⠙⠛⠻⠿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
	//⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠟⡋⢅⡊⠑⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠛⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
	//⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠟⡝⢁⢀⣱⣾⢿⣷⣳⣪⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
	//⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢟⢥⣼⢲⣻⣹⣟⣿⣿⣿⣿⢽⠡⣰⡔⡧⡦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
	//⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⢃⣣⣿⣿⢧⣟⢧⣼⣿⣿⣿⡿⣜⣻⠻⣃⡿⡧⠣⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
	//⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⣡⢽⡽⡾⢻⣼⣹⢿⣿⣻⢿⣳⣿⣼⣮⢷⣥⣻⡿⣆⠈⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⢤⣀⠦⡄⡄⢀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
	//⣿⣿⣿⣿⣿⣿⣿⣿⣿⠟⢀⡞⣿⣻⣿⣦⢻⣽⡿⣿⣽⣻⣿⣿⣿⣿⣿⣾⣿⣿⣽⠀⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⢞⡹⢦⡝⣮⣱⡽⣦⣉⠲⡀⠀⠀⠀⠀⠀⠀⠀⠘⡕⡙⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿
	//⣿⣿⣿⣿⣿⣿⣿⣿⢃⢺⣯⣟⣿⣟⣽⢶⣻⣿⡹⣻⣷⣿⣿⣿⣿⣿⣿⣿⣿⣿⣯⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣞⣮⢿⣿⣽⣶⣿⣿⣿⣽⣷⡘⣆⠀⠀⠀⠀⠀⠀⠀⠀⠠⠈⢿⣿⣿⣿⣿⣿⣿⣿⣿
	//⣿⣿⣿⣿⣿⣿⣿⠃⡰⣻⣏⣿⣛⡿⢿⣞⣻⠿⣵⣻⢾⣿⣿⣿⣿⣿⣿⣿⣿⣿⢿⠃⠀⠀⠀⣀⠀⠀⠀⠀⠀⢄⢻⡯⢿⣻⢿⡿⣿⣿⣿⣿⣿⣿⡞⠄⡠⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⣿⣿⣿⣿⣿⣿⣿
	//⣿⣿⣿⣿⣿⡿⠁⡼⣟⣿⣯⣷⣿⣭⣛⡯⡛⣴⢳⢯⡿⣿⣿⣿⣿⣿⣿⣿⣿⡟⠁⠃⠀⠀⠀⠣⠀⠀⠀⠀⠀⠀⠈⠳⡍⠲⠉⠚⣳⢻⢯⡿⣿⣻⡇⡬⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⣿⣿⣿⣿⣿⣿
	//⣿⣿⣿⣿⣿⠃⠀⣿⣿⣿⣷⣯⣿⣶⣏⣳⣵⢨⢇⢯⡽⣳⢯⣿⣿⣿⠿⠛⠁⠀⠀⡇⣰⢸⡀⠀⠀⠀⠀⠀⠀⢃⠀⠀⠈⠑⠐⠠⠌⢣⣛⣼⣳⡟⠴⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢿⣿⣿⣿⣿⣿
	//⣿⣿⣿⣿⢏⢌⡞⣿⣿⣿⣿⣷⣿⡟⡿⡻⢶⣻⡾⣎⡻⣟⡛⣽⣗⠄⣠⣤⠀⠔⢑⠢⢬⣆⠀⠀⠀⠀⠀⠀⠀⠘⠙⠦⡤⠤⣀⠀⠀⠀⢀⠀⠀⠀⠀⠈⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣿⣿⢿⣿⣿
	//⣿⣿⣿⡟⠀⡼⣮⣿⣿⣿⣯⢷⣹⣾⣷⣿⣿⣯⣿⣾⣿⣿⡟⠿⢾⡛⡍⡅⠰⣀⢎⣷⡀⣻⣣⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⠊⠐⠈⠀⠁⠑⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⣿⣿⡿⣿
	//⣿⣿⣿⡇⢀⣷⡿⣿⣿⣱⣾⢿⣿⣿⡿⣹⢋⠼⡍⢿⡞⠞⠡⣂⢂⣉⡔⡚⣅⢰⢱⣿⣟⣷⡷⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⢅⣦⣈⠂⡐⠠⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢁⠈⣿⣷⣿⣿
	//⣿⣿⣿⡁⢚⣿⣝⣿⡏⣹⣯⣟⣵⣶⣖⡷⣌⢶⣰⣆⣠⢙⣀⡼⠶⠟⢠⡝⠑⣀⣿⣳⣄⣿⣯⢄⢀⠀⠀⠀⠀⠀⠀⢀⠀⠰⣌⠘⢟⠛⣦⣄⡐⠤⢄⣀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠂⠀⡜⣿⣿⣽⣿
	//⣿⣿⣽⢃⠳⢷⡿⣯⣽⣿⣿⣿⣿⣻⣿⡿⣾⣿⣿⣿⣷⡿⣯⣔⡰⢄⣲⠅⣿⣾⣿⣿⣿⣿⣿⣾⣷⣷⣶⣿⣿⣿⡠⠄⠐⡀⠹⣦⡀⠻⣌⢿⣟⢏⡛⠺⣌⠉⡐⠀⠀⠀⠀⠀⠀⠀⠄⠰⢚⢤⣿⣟⣯⣿
	//⣿⣿⢿⣸⢱⣿⣇⡿⣿⣷⣿⣿⣶⣿⣷⢿⣷⢿⣾⣿⣿⣿⣿⣿⣹⢷⡿⣏⣶⢏⡿⣿⣿⣿⣿⣿⣿⣿⡆⢷⡈⠷⣀⠇⠀⢷⡀⠹⣾⣶⣎⣿⣉⣇⡹⢶⣈⡀⠀⠀⠀⠀⠀⠀⠀⠀⡸⣸⣸⢁⣿⡿⣿⣿
	//⣿⡿⣿⣽⠀⣻⣿⢫⣿⣿⣿⢿⣻⣿⣿⣿⢾⣿⣷⣿⣿⣿⣿⣿⣿⣿⣷⣿⣿⣿⣿⢿⣯⣿⠿⡿⠻⢟⣾⠦⣐⠻⣟⣷⣦⣤⣿⣷⣼⣭⣞⣽⣿⣻⣿⣔⢮⣽⠖⠢⣀⡀⠐⣤⣴⣯⢇⡛⣸⣇⣿⡿⣯⣿
	//⣿⣿⢿⡧⣦⡾⣿⣹⣿⣿⣿⣿⣿⣿⣿⢿⣯⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣾⣿⣿⣿⣿⣿⣿⣿⣿⣵⣻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣞⣟⣤⣩⢴⣧⣾⢨⣏⣯⣗⣮⣻⢿⢘⣿⣟⣿⣽
	//⣿⣿⣻⡇⡷⣽⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣲⢿⡽⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢿⣭⡼⣧⡛⣫⢷⣻⣻⣯⣿⣿⣿⢺⣿⣽⣯⣿
	//⣿⣷⢿⣿⣰⣻⣽⣿⣿⣿⣿⣿⣿⣿⣿⢿⣟⠦⡙⣜⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢻⡟⢿⣙⡝⢻⡺⢯⣟⣟⣿⣿⣛⠛⣾⡽⣾⣯⣾⡿⣞⣷⣿
	//⣿⣯⣿⣻⣧⢿⣟⣿⣿⣿⣿⣯⣿⡿⣿⣟⢾⣿⡐⣸⡇⠼⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢫⢧⢃⡞⠄⡛⣤⣽⣻⡾⣟⣿⢿⣴⣿⡿⣿⣾⣟⣿⣯⣟⣿⣽⣾
	//⣿⣯⣷⣟⣿⣯⣿⣟⣿⣿⣿⣿⣿⣿⣿⣟⣻⢷⡵⣉⣶⡑⡮⣿⣟⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢿⡟⢎⠲⡨⠑⠋⣰⣏⡸⢿⣧⣿⣿⡿⣿⣙⣾⡿⣿⣾⣿⣟⣷⣻⣾⢯⣿
	//⣿⣟⣾⣟⡾⣿⣟⣿⣿⣿⣿⣿⣿⣿⣽⣿⣿⣿⡿⣿⡽⣿⣹⢞⡿⡽⣿⢯⡿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⣿⠛⢬⡽⣒⠆⡷⢚⣽⢛⣮⣿⢿⣿⣿⣿⣻⣿⣿⣿⣿⣾⣿⣷⣻⢾⣽⡾⣿⣻
	//⣿⣯⣷⢿⣻⢷⣿⣻⣿⣿⣿⣿⣿⣾⣿⣿⣿⣟⣿⣿⣿⣿⣿⢾⣿⣿⣯⣿⣷⣿⡼⣟⣻⢯⣝⣿⣻⡻⡽⣽⠞⢺⢱⢯⣸⣷⣣⣼⡿⣏⣜⣯⢶⠾⣷⢷⣿⣿⢿⣷⣿⣿⣿⣿⣽⣿⡿⣾⡽⣯⣷⢿⣟⣿
	//⣿⣟⣾⣿⣻⣯⣟⣿⣽⣿⣿⣿⣿⣿⣿⣻⣿⣿⣿⣯⣿⣽⣿⣿⣽⣿⣿⣿⣿⣿⣿⣷⣿⣿⣿⣽⣾⣽⣿⣯⣿⣯⣿⣯⣷⣿⣿⣽⡷⣾⣼⣚⣽⣿⣟⡿⡿⣟⣿⡿⠿⣿⣿⣿⣿⢿⣽⣳⢿⣽⡾⣿⣻⣿
	//⣿⣟⣿⡾⣟⣷⢿⣞⡿⣟⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣷⣿⣭⣿⣿⣾⣿⣟⣻⣿⣿⣿⣿⣿⢯⣟⡾⣽⣻⡾⣟⣿⣽⣿
	//⣿⣿⣻⣽⣿⢯⣿⣾⣻⣟⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⣟⣫⣿⣿⣞⣻⣿⣶⣿⣿⢿⣟⣿⣿⣿⣿⣿⣿⡿⢯⣟⡾⣽⣟⣷⢿⣻⣯⣿⢿
	//⣿⣿⣿⡟⣾⣿⢳⣯⣷⡟⣾⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⣿⣿⣾⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣯⡟⣿⣾⣽⡟⣾⣯⣿⣿⣽⣿⣿
	//⣿⣿⣾⣿⢿⣻⡿⣯⣿⡽⣯⣟⡾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⢾⣿⢿⣿⠿⣿⢿⣿⣾⣿⣿⡿⢿⣻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣛⡾⣽⣳⢯⣷⢿⣯⣿⣻⣾⢿⣷⣿
	//⣿⣿⣯⣿⣿⣟⣿⣟⣾⢿⣽⣯⣟⣷⣻⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣾⣾⣿⣼⣿⣻⣿⣿⣿⣿⣿⣷⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢻⣞⣽⣻⢷⣻⣯⣟⣯⣷⣿⣻⣽⡿⣯⣿
	//⣿⣿⣿⣯⣷⣿⣯⣿⢯⣿⣷⣻⢾⣳⣯⣟⣾⣻⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢻⣳⣞⡿⣞⡷⣯⡿⣷⣯⢿⣯⣷⡿⣟⣯⣿⢿⣽
	//⣿⣿⣷⣿⣿⣯⣿⣽⡿⣟⣾⣟⣿⡽⣾⡽⣾⣽⣻⣞⡿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⣟⣳⡽⣯⢷⣯⢿⣽⣻⣷⢿⣟⣾⣿⣻⣽⣿⣿⣿⣻⣿⣿
	//⣿⣿⣿⣿⣷⣿⣟⣯⣿⡿⣟⣾⣯⡿⣷⢿⣳⣯⢷⣯⣟⡷⣯⢿⣿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⣿⢯⢷⣻⣽⣳⢿⣽⣻⢾⣯⣷⢿⣾⣿⣻⣯⣿⣿⢿⣿⣿⣿⣿⣿⣿
	//⣿⣿⣿⣿⣿⣯⣿⣿⣻⣿⢿⣯⣷⡿⣟⣿⢯⣿⣟⣾⣽⣻⣽⣻⣞⣯⣟⣿⣻⢿⣿⢿⣿⢿⣿⣿⣿⣿⣿⢿⣿⢻⢿⣹⣏⡷⡽⣞⣧⣟⣯⢷⣯⣟⡿⣾⣽⢿⣳⣿⢿⣻⣾⣿⢿⣻⣿⣿⣿⣿⣿⣿⣿⣿



	/// <summary>
	/// Data class to invoke methods in order to manage files.
	/// </summary>
	public class FileManager {

		/// <summary>
		/// Saves the user's data into a json-file.
		/// </summary>
		/// <param name="fileName"></param>
		/// <param name="user"></param>
		public void Save(string fileNameInput, User user) {
			string fileName = $"SaveFile-{fileNameInput}.json";
			string backupFileName = $"SaveFile-{fileNameInput}-Backup.json";
			try {
				string serialized = JsonSerializer.Serialize(user);

				if (File.Exists(backupFileName) || File.Exists(fileName)) {
					Console.WriteLine("\nFile found!");
				} else {
					Console.WriteLine("\nFile not found. Creating a new file.");
				}

				File.WriteAllText(fileName, serialized);
				File.WriteAllText(backupFileName, serialized);

				Console.WriteLine("User data saved successfully!");
				Console.WriteLine("Saved data:");
				user.DisplayInfo();
			} catch (ArgumentException e) {
				Console.WriteLine($"\nSomething went wrong! {e.Message}");
			}
		}

		/// <summary>
		/// Displays all save files and backup files.
		/// </summary>
		public void DisplayAllFiles() {
			string filePath = AppDomain.CurrentDomain.BaseDirectory;
			string[] saveFiles = Directory.GetFiles(filePath, "SaveFile-*.json");
			int fileAmount = 0;

			Console.WriteLine("All current savefiles:\n(Alphabetical Order)\n");
			try {
				for (int i = 0; i < saveFiles.Length; i += 2) {
					int saveIndex = i+1;
					int backupIndex = i;
					fileAmount++;

					Console.WriteLine($"{fileAmount}: {Path.GetFileName(saveFiles[saveIndex]), -30} : {Path.GetFileName(saveFiles[backupIndex])}");
				}
				if (saveFiles.Length > 0) {
					//Gets filenames from filepaths.
					//Converts to an array for next method to function.
					string[] fileNames = saveFiles.Select(file => Path.GetFileName(file)).ToArray();

					//Sorts for last modified file.
					string latestFile = saveFiles
						.OrderByDescending(f => File.GetLastWriteTime(f))
						.FirstOrDefault();
					DateTime lastWriteTime = File.GetLastWriteTime(latestFile);

					Console.WriteLine($"\nLatest saved file: {lastWriteTime}:\n{Path.GetFileName(latestFile)}");
				} 
				else {
					Console.WriteLine("No matching files found.");
				}
				Console.WriteLine();
			} catch (ArgumentException e) {
				Console.WriteLine($"\nSomething went wrong! {e.Message}");
			}
		}
	
	}
}
