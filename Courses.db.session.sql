
DROP TABLE IF EXISTS CourseMatch;

DROP TABLE IF EXISTS Pairs;

CREATE TABLE Pairs (
    MajorID INT(7),
    CourseID INT(10),
    FOREIGN KEY (CourseID) REFERENCES Course(CourseID),
    FOREIGN KEY (MajorID) REFERENCES Major(Id)
);

CREATE TABLE CourseMatch (
    CourseCode VARCHAR(10),
    PreCoreq VARCHAR(50) NOT NULL,
    CourseID INT(10),
    PreCourseCode VARCHAR(10),
    FOREIGN KEY (CourseCode) REFERENCES Course(CourseCode),
    FOREIGN KEY (CourseID) REFERENCES Course(CourseID),
    FOREIGN KEY (PreCourseCode) REFERENCES Prerequisites(PreCourseCode),
    PRIMARY KEY (CourseCode, PreCoreq, CourseID)
);