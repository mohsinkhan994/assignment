export class Client {
    id: number;

    FirstName: string;

    LastName: string;

    Dob: string;

    clientAddress: Address[];

}
export class Address{

    id: number;
    clientId: number;
    clientAdd: string;


}
