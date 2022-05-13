import { ProcessingChargeDetails } from "./processing-charge.model";

export interface PaymentInfo {
    requestId: number;
    creditCardNuber: number;
    creditLimit: number;
    totalProcessingCharge: number;
    processResponse: ProcessingChargeDetails;
}