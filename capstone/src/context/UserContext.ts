import { createContext } from "react";
import { User } from "../Components/LoginComponent/LoginComponent";

export const UserContext = createContext<User | undefined>(undefined);