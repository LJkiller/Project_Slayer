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
		public  void Save(string fileNameInput, User user) {
			string fileName = $"SaveFile-{fileNameInput}.json";
			string backupFileName = $"SaveFile-{fileNameInput}-Backup.json";
			try {
				string serialized = JsonSerializer.Serialize(user);

				if (File.Exists(fileName)) {
					Console.WriteLine("\nThe file already exists and will be overwritten.");
				} else {
					Console.WriteLine("\nThe file does not exist. Creating a new file.");
				}

				File.WriteAllText(fileName, serialized);
				File.WriteAllText(backupFileName, serialized);

				Console.WriteLine("User data saved successfully!");
				Console.WriteLine("Saved data:");
				user.DisplayInfo();
				Console.WriteLine(serialized);
			} catch (ArgumentException e) {
				Console.WriteLine($"\nSomething went wrong! {e.Message}");
			}
		}

		/// <summary>
		/// Displays all save files and backup files.
		/// </summary>
		public void DisplayAllFiles() {
			string filePath = AppDomain.CurrentDomain.BaseDirectory;

			Console.WriteLine("All current savefiles:");
			try {
				string[] saveFiles = Directory.GetFiles(filePath, "SaveFile-*");
				string[] saveFileBackups = Directory.GetFiles(filePath, "SaveFile-*-Backup");

				for (int i = 0; i<saveFiles.Length; i++) {
					Console.WriteLine($"{Path.GetFileName(saveFiles[i])} : {Path.GetFileName(saveFileBackups[i])})");
				}
				Console.WriteLine();

			} catch (ArgumentException e) {
				Console.WriteLine($"\nSomething went wrong! {e.Message}");
			}

		}
	
	}
}
