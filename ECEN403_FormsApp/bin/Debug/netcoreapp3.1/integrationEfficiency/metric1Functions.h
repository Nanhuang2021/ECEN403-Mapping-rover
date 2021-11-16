#ifndef METRIC_1_FUNCTIONS_H
#define METRIC_1_FUNCTIONS_H

#include <string>

/*double calculate_area_OLD();*/

double identify_average_coordinate_from_a_list_of_coordinates (const std::string& file_of_coordinates, bool X_OR_Y);

double calculate_area_bretschneider(double ax, double ay, double bx, double by, double cx, double cy, double dx, double dy);

std::vector <double> four_corners_finder(double average_coord_val_x, double average_coord_val_y, const std::string& file_of_coordinates);

#endif