# Just run a cute little python check.py in the terminal if you have python installed
# and this should run ;) 923 total course/objs in the json file
import json

input_file = open ('./SqliteDB/database/table_info/courseData.js')
json_arr = json.load(input_file)

courses_list = []
dupCourses = []
uniqueCourses= []

for item in json_arr:
    courseCode = {"CourseCode:":None}
    courseCode['CourseCode:'] = item["CourseCode:"]
    courses_list.append(courseCode)

# print(courses_list)

for pair in courses_list:
    for course in pair.items():
        if pair not in uniqueCourses:
            uniqueCourses.append(course)
        else:
            dupCourses.append(course)

print("Dup Courses: ", dupCourses)
print("Unique Courses:", len(uniqueCourses))
print("Total Courses:", len(courses_list))

for pair in courses_list:
    for course in pair.items():
        if course == "COMM4950":
            print("Dupped")

print("not Dupped")
