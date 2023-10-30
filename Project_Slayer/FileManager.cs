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

		#region User related

		/// <summary>
		/// Saves the user's data into a json-file with a specified file name.
		/// </summary>
		/// <param name="fileName">String to be handled as the User's file name.</param>
		/// <param name="user">The User object to be handled in the method.</param>
		/// <exception cref="ArgumentException">Thrown when an error occurs during the saving process.</exception>
		public void Save(string fileNameInput, User user) {
			string fileName = $"SaveFile-{fileNameInput}.json";
			string backupFileName = $"SaveFile-{fileNameInput}-Backup.json";
			try {
				int durability = user.GetDurability();
				user.HitPoints = durability;
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
				user.DisplayInfo(false);
			} catch (ArgumentException e) {
				Console.WriteLine($"\nSomething went wrong! {e.Message}");
			}
		}

		#endregion

		#region Purely Files

		/// <summary>
		/// Displays all save files and backup files in the current directory.
		/// </summary>
		/// <exception cref="ArgumentException">Thrown when error occurs during the process of displaying files.</exception>
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

		#endregion

		#region FileName Management
		private string savedFileName;
		private string backupFileName;

		/// <summary>
		/// Stores the primary file name.
		/// </summary>
		/// <param name="fileNameInput">String to be handled as the User's file name.</param>
		public void SaveFileName(string fileNameInput) {
			string fileName = $"SaveFile-{fileNameInput}.json";
			savedFileName = fileName;
		}
		/// <summary>
		/// Stores the backup file name.
		/// </summary>
		/// <param name="fileNameInput">String to be handled as the User's backup file name.</param>
		public void BackupFileName(string fileNameInput) {
			string fileName = $"SaveFile-{fileNameInput}-Backup.json";
			backupFileName = fileName;
		}

		/// <summary>
		/// Retrieves the saved file name.
		/// </summary>
		/// <returns>The saved file name as a string.</returns>
		public string GetSavedFileName() {
			return savedFileName;
		}

		/// <summary>
		/// Retrieves the save file name.
		/// </summary>
		/// <returns>The backup file name as a string.</returns>
		public string GetBackupFileName() {
			return backupFileName;
		}

		#endregion
	}
}
