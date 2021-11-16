#include <iostream>
#include <iomanip>
#include <string>
#include <fstream>
#include <vector>
#include "metric1Functions.h"
#include <cmath>


using std::string, std::cout, std::endl, std::cin, std::ifstream, std::ofstream;


/*double calculate_area_OLD(){
	std::string filename1 = "file_of_southern_wall_coordinates.txt";
	std::string filename2 = "file_of_eastern_wall_coordinates.txt";
	std::string filename3 = "file_of_northern_wall_coordinates.txt";
	std::string filename4 = "file_of_western_wall_coordinates.txt";
	double line_1_wye_avg_coord = identify_average_coordinate_from_a_list_of_coordinates(filename1);
	double line_2_ex_avg_coord = identify_average_coordinate_from_a_list_of_coordinates(filename2);
	double line_3_wye_avg_coord = identify_average_coordinate_from_a_list_of_coordinates(filename3);
	double line_4_ex_avg_coord = identify_average_coordinate_from_a_list_of_coordinates(filename4);
	double area_calc = (line_1_wye_avg_coord - line_3_wye_avg_coord) * 
					   (line_2_ex_avg_coord - line_4_ex_avg_coord);
	if (area_calc < 0){
		area_calc *= -1;
	}
	
	return area_calc;
}*/

double identify_average_coordinate_from_a_list_of_coordinates (const std::string& file_of_coordinates, bool X_OR_Y){
	
	//string coord_string = " ";
	double coord_val_x = 0;
	double coord_val_y = 0;
	double sum_coords_x = 0;
	double sum_coords_y = 0;
	double number_of_coords_x = 0;
	double number_of_coords_y = 0;
	double average_coord_val_x = 0;
	double average_coord_val_y = 0;
	std::string currentLine = " ";
	
	std::ifstream inLucas;
	inLucas.open(file_of_coordinates);
	if (!inLucas.is_open()){
		std::cout << "Could not open file" << std::endl;
		return 1;
	}
	while (!inLucas.eof()){
		inLucas >> coord_val_x;
		inLucas >> coord_val_y;
		sum_coords_x += coord_val_x;
		sum_coords_y += coord_val_y;
		number_of_coords_x += 1;
		number_of_coords_y += 1;
	}
	inLucas.close();
	
	average_coord_val_x = sum_coords_x / number_of_coords_x;
	average_coord_val_y = sum_coords_y / number_of_coords_y;
	
	if (X_OR_Y){
		return average_coord_val_x;
	}
	
	else {
		return average_coord_val_y;
	}
	
}

double calculate_area_bretschneider(double ax, double ay, double bx, double by, double cx, double cy, double dx, double dy){
	double AC_squared = ((cx - ax)*(cx - ax)) + ((cy - ay)*(cy - ay));
	double BD_squared = ((dx - bx)*(dx - bx)) + ((dy - by)*(dy - by));
	double AB_squared = ((bx - ax)*(bx - ax)) + ((by - ay)*(by - ay));
	double BC_squared = ((cx - bx)*(cx - bx)) + ((cy - by)*(cy - by));
	double CD_squared = ((dx - cx)*(dx - cx)) + ((dy - cy)*(dy - cy));
	double DA_squared = ((ax - dx)*(ax - dx)) + ((ay - dy)*(ay - dy));
	double area_of_figure = (1.0/4.0) * sqrt((4 * AC_squared * BD_squared) - 
		   ((AB_squared - BC_squared + CD_squared - DA_squared)*(AB_squared - 
		   BC_squared + CD_squared - DA_squared)));
		   
return area_of_figure;

}

std::vector <double> four_corners_finder(double average_coord_val_x, double average_coord_val_y, const std::string& file_of_coordinates){
	std::string currentLine = " ";
	double coord_val_x = 0;
	double coord_val_y = 0;
	
	double prospective_distance__NE = 0;
	double distance_to_beat__NE = 0;
	double max_x_coord__NE = 0;
	double max_y_coord__NE = 0;
	
	double prospective_distance__NW = 0;
	double distance_to_beat__NW = 0;
	double max_x_coord__NW = 0;
	double max_y_coord__NW = 0;
	
	double prospective_distance__SE = 0;
	double distance_to_beat__SE = 0;
	double max_x_coord__SE = 0;
	double max_y_coord__SE = 0;
	
	double prospective_distance__SW = 0;
	double distance_to_beat__SW = 0;
	double max_x_coord__SW = 0;
	double max_y_coord__SW = 0;
	
	std::ifstream inLucas;
	inLucas.open(file_of_coordinates);
	if (!inLucas.is_open()){
		std::cout << "Could not open file" << std::endl;
	}
	while (!inLucas.eof()){
		inLucas >> coord_val_x;
		inLucas >> coord_val_y;
		if ((coord_val_x > average_coord_val_x) && (coord_val_y > average_coord_val_y)){  //Northeast Checker
			prospective_distance__NE = sqrt(pow(coord_val_x - average_coord_val_x, 2) + pow(coord_val_y - average_coord_val_y, 2));
			if (prospective_distance__NE > distance_to_beat__NE){
				max_x_coord__NE = coord_val_x;
				max_y_coord__NE = coord_val_y;
				distance_to_beat__NE = prospective_distance__NE;
			}
		}
		
		else if ((coord_val_x < average_coord_val_x) && (coord_val_y > average_coord_val_y)){ //Northwest Checker
			prospective_distance__NW = sqrt(pow(coord_val_x - average_coord_val_x, 2) + pow(coord_val_y - average_coord_val_y, 2));
			if (prospective_distance__NW > distance_to_beat__NW){
				max_x_coord__NW = coord_val_x;
				max_y_coord__NW = coord_val_y;
				distance_to_beat__NW = prospective_distance__NW;
			}
		}
		
		else if ((coord_val_x > average_coord_val_x) && (coord_val_y < average_coord_val_y)){ //Southeast Checker
			prospective_distance__SE = sqrt(pow(coord_val_x - average_coord_val_x, 2) + pow(coord_val_y - average_coord_val_y, 2));
			if (prospective_distance__SE > distance_to_beat__SE){
				max_x_coord__SE = coord_val_x;
				max_y_coord__SE = coord_val_y;
				distance_to_beat__SE = prospective_distance__SE;
			}
		}
		
		else if ((coord_val_x < average_coord_val_x) && (coord_val_y < average_coord_val_y)){ //Southwest Checker
			prospective_distance__SW = sqrt(pow(coord_val_x - average_coord_val_x, 2) + pow(coord_val_y - average_coord_val_y, 2));
			if (prospective_distance__SW > distance_to_beat__SW){
				max_x_coord__SW = coord_val_x;
				max_y_coord__SW = coord_val_y;
				distance_to_beat__SW = prospective_distance__SW;
			}
		}
		
	}
	inLucas.close();
	std::vector<double> four_corners_8 {max_x_coord__NE, max_y_coord__NE, max_x_coord__NW, max_y_coord__NW, 
	                                    max_x_coord__SE, max_y_coord__SE, max_x_coord__SW, max_y_coord__SW};
										
	return four_corners_8;
}