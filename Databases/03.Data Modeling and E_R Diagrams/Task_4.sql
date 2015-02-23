-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema university
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema university
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `university` DEFAULT CHARACTER SET utf8 ;
USE `university` ;

-- -----------------------------------------------------
-- Table `university`.`faculties`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `university`.`faculties` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `university`.`departments`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `university`.`departments` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `FacultyId` INT(11) NOT NULL,
  `Name` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `FK_Departments_Faculties` (`FacultyId` ASC),
  CONSTRAINT `FK_Departments_Faculties`
    FOREIGN KEY (`FacultyId`)
    REFERENCES `university`.`faculties` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `university`.`persons`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `university`.`persons` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `FirstName` VARCHAR(50) NOT NULL,
  `LastName` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `university`.`professors`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `university`.`professors` (
  `Id` INT(11) NOT NULL,
  `DepartmentId` INT(11) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `UK_Professors_Id` (`Id` ASC),
  INDEX `FK_Professors_Departments` (`DepartmentId` ASC),
  CONSTRAINT `FK_Professors_Departments`
    FOREIGN KEY (`DepartmentId`)
    REFERENCES `university`.`departments` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_Professors_Persons`
    FOREIGN KEY (`Id`)
    REFERENCES `university`.`persons` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `university`.`courses`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `university`.`courses` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(100) NOT NULL,
  `ProfessorId` INT(11) NOT NULL,
  `DepartmentId` INT(11) NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `FK_Courses_Professors` (`ProfessorId` ASC),
  INDEX `FK_Courses_Departments` (`DepartmentId` ASC),
  CONSTRAINT `FK_Courses_Departments`
    FOREIGN KEY (`DepartmentId`)
    REFERENCES `university`.`departments` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_Courses_Professors`
    FOREIGN KEY (`ProfessorId`)
    REFERENCES `university`.`professors` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `university`.`degrees`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `university`.`degrees` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `Title` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `university`.`degreesprofessors`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `university`.`degreesprofessors` (
  `ProfessorId` INT(11) NOT NULL,
  `DegreeId` INT(11) NOT NULL,
  PRIMARY KEY (`ProfessorId`, `DegreeId`),
  INDEX `FK_DegreesProfessors_Degrees` (`DegreeId` ASC),
  CONSTRAINT `FK_DegreesProfessors_Degrees`
    FOREIGN KEY (`DegreeId`)
    REFERENCES `university`.`degrees` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_DegreesProfessors_Professors`
    FOREIGN KEY (`ProfessorId`)
    REFERENCES `university`.`professors` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `university`.`students`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `university`.`students` (
  `Id` INT(11) NOT NULL,
  `FacultyId` INT(11) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `UK_Students_Id` (`Id` ASC),
  INDEX `FK_Students_Faculties` (`FacultyId` ASC),
  CONSTRAINT `FK_Students_Faculties`
    FOREIGN KEY (`FacultyId`)
    REFERENCES `university`.`faculties` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_Students_Persons`
    FOREIGN KEY (`Id`)
    REFERENCES `university`.`persons` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `university`.`studentscourses`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `university`.`studentscourses` (
  `StudentId` INT(11) NOT NULL,
  `CourseId` INT(11) NOT NULL,
  PRIMARY KEY (`StudentId`, `CourseId`),
  INDEX `FK_StudentsCourses_Courses` (`CourseId` ASC),
  CONSTRAINT `FK_StudentsCourses_Courses`
    FOREIGN KEY (`CourseId`)
    REFERENCES `university`.`courses` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_StudentsCourses_Students`
    FOREIGN KEY (`StudentId`)
    REFERENCES `university`.`students` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
