import { createReducer, on } from '@ngrx/store';
import { clearAuthToken, setIsLogged } from './auth.actions';

export interface AuthState {
  isLogged: boolean;
}

export const initialState: AuthState = {
  isLogged: false,
};

export const authReducer = createReducer(
  initialState,
  on(clearAuthToken, (state) => {
    console.log('clearAuthToken action triggered'); // Debug log
    return { ...state, isLogged: false };
  }),
  on(setIsLogged, (state, { isLogged }) => {
    console.log('setIsLogged action triggered with:', isLogged); // Debug log
    return { ...state, isLogged };
  })
);
