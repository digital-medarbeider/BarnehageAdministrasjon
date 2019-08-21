import { ApplicationSpecRequirement } from './application-spec-requirement.model';
import { ApplicationKindergartenCoverage } from './application-kindergarten-coverage.model';
import { Person } from './person.model';
import { Municipality } from './municipality.model';

export class Application {
  applicationId: string;
  childId: string;
  child: Person;
  fatherId: string;
  father: Person;
  motherId: string;
  mother: Person;
  municipalityId: number;
  childName?: string;
  childAddress?: string;
  fatherName?: string;
  motherName?: string;
  firstLanguage?: string;
  levelOfSpoken?: string;
  applicationStartDate: Date;
  isReducedFee: boolean;
  isChooseDiffDays: boolean;
  applicationSubmitDate: Date;
  kindergartenCoverage: number;
  status: string;
  municipality?: Municipality;
  applicationSpecRequirements: ApplicationSpecRequirement[];
  applicationKindergartenCoverages: ApplicationKindergartenCoverage[];
}
