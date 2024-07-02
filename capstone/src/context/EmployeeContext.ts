import { createContext } from "react";
import { Employee } from "../Components/AdminComponent/UpdateProfileComponent";

export const EmployeeContext = createContext<Employee | undefined>(undefined);