import { ComponentDetails } from "./component-details.model";
import { ProcessingChargeDetails } from "./processing-charge.model";

export interface UserRequestDetails {
    processRequests: ComponentDetails[];
    processResponses: ProcessingChargeDetails[];
}

export interface UserRequestSummary {
    requestId: number;
    defectiveComponentType: string;
    defectiveComponentName: string;
    quantity: number;
    processingCharge: number;
    packagingAndDeliveryCharge: number;
    dateOfDelivery: Date;
}