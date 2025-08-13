// Modelo para el registro de cliente
export interface CustomerRegister {
  name: string;
  email: string;
  password: string;
  phoneNumber?: string;
  address?: string;
  city?: string;
  gender?: string;
}
