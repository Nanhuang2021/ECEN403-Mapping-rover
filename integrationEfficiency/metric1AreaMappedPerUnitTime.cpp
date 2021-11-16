#include <iostream>
#include <iomanip>
#include <string>
#include <vector>
#include "metric1Functions.h"

using std::string, std::cout, std::endl, std::cin;


int main(){



cout << " - - - - - - - - - - - - - - - - - - - - - - - -" << endl; // needs to be changed

//std::vector<double> averageCoordinateXY (2);

string fileName = "";
double timeToMapSeconds = 0.0;

// needs to be changed
// ***************
cout << "Enter file name where coordinates are held: ";
cin >> fileName;
cout << "Enter time taken to map room in seconds: ";
cin >> timeToMapSeconds;
//*****************

// needs to be changed
double averageCoordinateX = identify_average_coordinate_from_a_list_of_coordinates (fileName, true);
double averageCoordinateY = identify_average_coordinate_from_a_list_of_coordinates (fileName, false);

// needs to be changed
cout << "Location of map center: " << averageCoordinateX << ", " << averageCoordinateY << endl;		

// needs to be changed			
std::vector <double> four_corners_8 = four_corners_finder(averageCoordinateX, averageCoordinateY, fileName);

// needs to be changed
double NE_corner_x = four_corners_8.at(0);      //note: this looks like this because the returned vector features all coordinates in the same vector, in order from
double NE_corner_y = four_corners_8.at(1);      //NE, NW, SE, SW, and with x's and y's separated.
double NW_corner_x = four_corners_8.at(2);
double NW_corner_y = four_corners_8.at(3);
double SE_corner_x = four_corners_8.at(4);
double SE_corner_y = four_corners_8.at(5);
double SW_corner_x = four_corners_8.at(6);
double SW_corner_y = four_corners_8.at(7);

// needs to be changed
cout << "Northeast corner: " << NE_corner_x << ", " << NE_corner_y << endl;
cout << "Northwest corner: " << NW_corner_x << ", " << NW_corner_y << endl;   
cout << "Southeast corner: " << SE_corner_x << ", " << SE_corner_y << endl; 
cout << "Southwest corner: " << SW_corner_x << ", " << SW_corner_y << endl;

// needs to be changed
double room_area_final_mm_squared = calculate_area_bretschneider(SW_corner_x, SW_corner_y, SE_corner_x, SE_corner_y, NE_corner_x, NE_corner_y, NW_corner_x, NW_corner_y);
// good
double room_area_final_m_squared = .000001 * room_area_final_mm_squared;
// needs to be changed
cout << "FINAL CALCULATION FOR AREA OF ROOM: " << room_area_final_mm_squared << " square millimeters or " << room_area_final_m_squared << " square meters." << endl;
// good
double room_mapping_efficiency_final_seconds = (room_area_final_m_squared) / timeToMapSeconds; 
double room_mapping_efficiency_final_minutes = room_mapping_efficiency_final_seconds * 60.0;
// needs to be changed
cout << "FINAL ROOM-MAPPING EFFICIENCY OF ROVER: " << room_mapping_efficiency_final_minutes << " square meters mapped per minute." << endl;




//cout << "Approximate area of the room, based on four corners: " << calculate_area_bretschneider(6.2, 0, 12, 0.15, 12.15, 5.3, 6.5, 5.5) << endl;
cout << " - - - - - - - - - - - - - - - - - - - - - - - -" << endl;		

string key = " ";
cout << "Enter any key to end application: " << endl;
cin >> key;
}